using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLayer : MonoBehaviour
{
    //[SerializeField] private LayerMask redMask;
    //[SerializeField] private LayerMask blueMask;

    [SerializeField] private Camera sceneCamera;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Red Layer"));
            Debug.Log("Red CULLED");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Blue Layer"));
            Debug.Log("Blue CULLED");
        }
    }
}
