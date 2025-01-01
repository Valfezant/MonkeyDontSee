using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float spikeDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerState>();
            player.DamagePlayer(spikeDamage);
            //player.playerHealth -= spikeDamage;
            //Debug.Log("yeeeouch!");

            var playerRb = other.GetComponent<Rigidbody2D>();
            playerRb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        }
    }
}
