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
        if (recentRespawnPoint != null)
        {
            player.transform.position = recentRespawnPoint.position;
        }

        //reset values
        var playerScript = player.GetComponent<PlayerState>();
        playerScript.playerHealth = playerScript.maxPlayerHealth;

        //hide Canvas
        //var canvas = GameObject.FindWithTag("Sacrifice Canvas").GetComponent<Canvas>();
        //canvas.enabled = false;
    }

    void Update()
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResurrectPlayer();
        }
    }
}
