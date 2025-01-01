using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeAltar : MonoBehaviour
{
    [SerializeField] private EyesManager eyesManager;

    private bool _playerClose;
    private bool _wasUsed;

    private void Start()
    {
        _wasUsed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerClose = false;
        }
    }

    void Update()
    {
        if (_playerClose && Input.GetKeyDown(KeyCode.E))
        {
            if (!_wasUsed)
            {
                eyesManager.RandomEye();
                _wasUsed = true;
            }
            else
            {
                Debug.Log("Already used.");
            }
        }
    }

}
