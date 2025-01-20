using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorLever : MonoBehaviour
{
    [SerializeField] private GameObject thisDoor;

    private bool _wasActivated;
    private bool _byLever;
    
    void Start()
    {
        _wasActivated = false;
        EyesManager.onPlayerGiveUp += RelockDoor;
    }

    void OnDisabled()
    {
        EyesManager.onPlayerGiveUp -= RelockDoor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _byLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {        
        if (other.CompareTag("Player"))
        {
            _byLever = false;
        }
    }
    
    void Update()
    {
        if ( _byLever && Input.GetKeyDown(KeyCode.E) && !_wasActivated)
        {
            OpenDoor();
            Debug.Log("yay");
            _wasActivated = true;
        }
    }

    //ANIMATION!!! (on lever too)
    private void OpenDoor()
    {
        thisDoor.GetComponent<Collider2D>().enabled = false;
        thisDoor.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    //ON PLAYER GIVEUP
    private void RelockDoor()
    {
        thisDoor.GetComponent<Collider2D>().enabled = true;
        thisDoor.GetComponent<SpriteRenderer>().color = Color.white;
        _wasActivated = false;
    }
}
