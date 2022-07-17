using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePX;
using UnityEngine.Tilemaps;

public enum TemporalBlockStatus{
    RELOCATING,
    WAITING,
    DESPAWNING,
    MELEE_ATTACK
}

public class Minotaur : Enemy
{
    public Transform player;
    float radiusMov = 6.0f;
    float radiusAttack = 2.0f;
    public TemporalBlockStatus currentStatus = TemporalBlockStatus.WAITING;
    public float speed = 1.5f;
    public Rigidbody2D rb;
    public GameObject tileMap;
    public Animator animator;

    private int[,] tileMapDescription;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        maxHearts = 3;
        hearts = maxHearts;

        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        tileMap = GameObject.FindGameObjectsWithTag("Floor")[0];
    }

    // Overwrite pauseChanged method to disable animator
    public override void pauseChanged(bool newPause){
        base.pauseChanged(newPause);
        animator.enabled = !pauseStatus;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        // Check Pause status to avoid movement.
        if(base.CheckPauseStatus()){
            return;
        }

        switch (currentStatus)
        {
            case TemporalBlockStatus.RELOCATING:
                relocate();
                break;

            case TemporalBlockStatus.WAITING:
                waiting();
                break;

            case TemporalBlockStatus.DESPAWNING:
                despawning();
                break;

            case TemporalBlockStatus.MELEE_ATTACK:
                meleeAttack();
                break;

            default:
                return;
        }
    }

    void meleeAttack(){
        if (Vector2.Distance(player.position, transform.position) > radiusAttack)
        {
            currentStatus = TemporalBlockStatus.RELOCATING;
        }

        if (Vector2.Distance(player.position, transform.position) <= radiusAttack/2)
        {
            return;
        }

        Vector3 targetWorldPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetWorldPosition.x, targetWorldPosition.y), Time.deltaTime * speed);

        animator.SetFloat("Horizontal", (targetWorldPosition.x - transform.position.x));
        animator.SetFloat("Vertical", (targetWorldPosition.y - transform.position.y));

        transform.position = Vector2.MoveTowards(transform.position,  new Vector2(targetWorldPosition.x, targetWorldPosition.y), Time.deltaTime * speed * 0.7f);
    }

    void relocate(){
        if (Vector2.Distance(player.position, transform.position) > radiusMov)
        {
            currentStatus = TemporalBlockStatus.WAITING;
        }

        animator.SetFloat("Speed", 1.0f);
        
        Pathfinder pathFinding = new Pathfinder();
        if (tileMapDescription == null) ConvertTilemap();
        Tilemap floor = tileMap.GetComponent<Tilemap>();
        Vector3Int myPos = tileMap.GetComponent<Tilemap>().WorldToCell(transform.position);
        int[] myPosition = {myPos.x - floor.cellBounds.xMin, myPos.y - floor.cellBounds.yMin};
        Vector3Int playerPos = tileMap.GetComponent<Tilemap>().WorldToCell(player.position);
        int[] playerPosition = {playerPos.x  - floor.cellBounds.xMin, playerPos.y - floor.cellBounds.yMin};
        List <int[]> result =  pathFinding.Astar(tileMapDescription, myPosition, playerPosition);

        if (result.Count > 0)
        {
            Vector3 targetWorldPosition = floor.CellToWorld(new Vector3Int(result[0][0] + floor.cellBounds.xMin, result[0][1] + floor.cellBounds.yMin, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetWorldPosition.x, targetWorldPosition.y), Time.deltaTime * speed);

            animator.SetFloat("Horizontal", (targetWorldPosition.x - transform.position.x));
            animator.SetFloat("Vertical", (targetWorldPosition.y - transform.position.y));
        }
        
        if (Vector2.Distance(player.position, transform.position) <= radiusAttack)
        {
            currentStatus = TemporalBlockStatus.MELEE_ATTACK;
        }
    }

    void waiting(){
        animator.SetFloat("Speed", 0.0f);

        if (Vector2.Distance(player.position, transform.position) <= radiusMov)
        {
            currentStatus = TemporalBlockStatus.RELOCATING;
        }
    }

    void despawning(){
    }

    public void ConvertTilemap()
    {
        Tilemap tilemap = tileMap.GetComponent<Tilemap>();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        tileMapDescription = new int[bounds.size.x,bounds.size.y];

        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    tileMapDescription[x, y] = 0;
                }
                else
                {
                    tileMapDescription[x, y] = -1;
                }
            }
        }
    }
}
