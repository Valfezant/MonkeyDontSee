using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    
    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyDamage;

    private Rigidbody2D enemyRb;
    [SerializeField] private Transform currentPoint;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            enemyRb.velocity = new Vector2(enemySpeed, 0);
        }
        else
        {
            enemyRb.velocity = new Vector2(-enemySpeed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerState>();
            player.DamagePlayer(enemyDamage);

            var playerRb = other.GetComponent<Rigidbody2D>();
            playerRb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        }
    }
}
