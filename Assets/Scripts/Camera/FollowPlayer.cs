using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -1);

    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
      
    void Update () 
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
