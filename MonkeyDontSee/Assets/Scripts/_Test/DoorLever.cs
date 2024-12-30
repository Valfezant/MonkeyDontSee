using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    [SerializeField] private GameObject thisDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter " + other.tag);
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
                OpenDoor();
                Debug.Log("yay");
            
        }
    }

    private void OpenDoor()
    {
        thisDoor.GetComponent<Collider2D>().enabled = false;
        thisDoor.GetComponent<SpriteRenderer>().color = Color.green;


    }
}
