using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassage : MonoBehaviour
{
    private bool _isOpen;
    private bool _playerNear;

    void Start()
    {
        _isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = false;
        }
    }

    void Update()
    {
        if ( _playerNear && Input.GetKeyDown(KeyCode.E) && !_isOpen)
        {
            OpenPassage();
            Debug.Log("opeeeen");
            _isOpen = true;
        }
    }

    private void OpenPassage()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
