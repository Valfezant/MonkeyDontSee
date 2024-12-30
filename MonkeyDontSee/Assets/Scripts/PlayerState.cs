using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //HP => die
    //n eyes & state
    //deactivate eye

    public float playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {
            Debug.Log("DIED");
        }
    }
}
