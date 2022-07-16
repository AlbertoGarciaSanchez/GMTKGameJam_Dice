using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePX;

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
    //public GameObject tileMap;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        //tileMap = GameObject.FindGameObjectsWithTag("Floor")[0];
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

        // TO BE REPLACED
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);

        /*Pathfinder pathFinding = new Pathfinder();
        pathFinding.Astar(tileMap, );*/
        
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
}
