using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    [SerializeField] private GameObject thisDoor;

    private bool _wasActivated;
    private bool _byLever;
    
    void Start()
    {
        _wasActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter " + other.tag);
        
        if (other.CompareTag("Player"))
        {
            _byLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Enter " + other.tag);
        
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
        thisDoor.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
