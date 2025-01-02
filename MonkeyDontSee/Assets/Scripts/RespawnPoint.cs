using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private RespawnPlayer respawnPlayer;

    void Start()
    {
        respawnPlayer = GameObject.FindWithTag("Manager").GetComponent<RespawnPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           respawnPlayer.recentRespawnPoint = gameObject.transform;
           Debug.Log("Respawn set!");
        }
    }
}
