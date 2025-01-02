using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform recentRespawnPoint;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    public void ResurrectPlayer()
    {
        //reposition
        player.transform.position = recentRespawnPoint.position;

        //reset values
        var playerScript = player.GetComponent<PlayerState>();
        playerScript.playerHealth = playerScript.maxPlayerHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResurrectPlayer();
        }
    }
}
