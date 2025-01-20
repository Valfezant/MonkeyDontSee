using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SacrificeAltar : MonoBehaviour
{
    [SerializeField] private EyesManager eyesManager;
    [SerializeField] private GameObject altarText;

    private bool _playerClose;
    private bool _wasUsed;

    private void Start()
    {
        _wasUsed = false;
        altarText.GetComponent<TextMeshPro>().text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerClose = true;
            altarText.GetComponent<TextMeshPro>().text = "Press E to perform sacrifice.";

            eyesManager.lastAltarTransform = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerClose = false;
            altarText.GetComponent<TextMeshPro>().text = "";
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
