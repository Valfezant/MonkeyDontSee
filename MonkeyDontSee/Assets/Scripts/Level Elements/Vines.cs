using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour
{
    [SerializeField] private Collider2D thisCollider;

    private PlayerMovement player;

    private bool _playerNear;
    
    void Start()
    {
        _playerNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerNear && player._onWall)
        {
            thisCollider.enabled = true;
        }
        else
        {
            thisCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();
            _playerNear = true;
        }
    }
}
