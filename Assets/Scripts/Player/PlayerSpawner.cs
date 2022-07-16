using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        player.transform.position = transform.position;
        FollowPlayer followPlayer = Camera.main.GetComponent<FollowPlayer>();
        followPlayer.player = player.transform;
        followPlayer.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
