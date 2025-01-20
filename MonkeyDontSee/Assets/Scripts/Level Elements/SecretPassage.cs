using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecretPassage : MonoBehaviour
{
    private bool _isOpen;
    private bool _playerNear;

    [SerializeField] private GameObject passageText;

    void Start()
    {
        _isOpen = false;
        passageText.GetComponent<TextMeshPro>().text = "";

        EyesManager.onPlayerGiveUp += ClosePassage;
    }

    void OnDisabled()
    {
        EyesManager.onPlayerGiveUp -= ClosePassage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isOpen)
        {
            _playerNear = true;
            passageText.GetComponent<TextMeshPro>().text = "Press E to open.";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = false;
            passageText.GetComponent<TextMeshPro>().text = "";
        }
    }

    void Update()
    {
        if ( _playerNear && Input.GetKeyDown(KeyCode.E) && !_isOpen)
        {
            OpenPassage();
            _isOpen = true;
        }
    }

    private void OpenPassage()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    //ON PLAYER GIVEUP
    private void ClosePassage()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _isOpen = false;
    }
}
