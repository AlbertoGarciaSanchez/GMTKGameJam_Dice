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

public class Enemy : MonoBehaviour
{
    public int hearts = 4;
    public Transform player;
    float radiusMov = 5.0f;
    float radiusAttack = 1.0f;
    public TemporalBlockStatus currentStatus = TemporalBlockStatus.WAITING;
    public float speed = 2;
    public Rigidbody2D rb;
    public GameObject tileMap;

    private int[,] tileMapDescription;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        tileMap = GameObject.FindGameObjectsWithTag("Floor")[0];
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void relocate(){
        if (Vector2.Distance(player.position, transform.position) > radiusMov)
        {
            currentStatus = TemporalBlockStatus.WAITING;
        }
        
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
        }
        
        if (Vector2.Distance(player.position, transform.position) <= radiusAttack)
        {
            currentStatus = TemporalBlockStatus.WAITING;
        }
    }

    void waiting(){
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
