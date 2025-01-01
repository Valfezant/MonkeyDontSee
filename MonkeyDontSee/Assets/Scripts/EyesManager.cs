using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesManager : MonoBehaviour
{
    //Scriptable objects con valori
    //lista di SO con numero
    //prendi int
    //prendi valore ed esegui

    [SerializeField] private Camera sceneCamera;

    [SerializeField] public Eye[] eyesArray;

    //canvases
    [SerializeField] private Canvas sacrificeCanvas; 
    
    void Start()
    {
        sacrificeCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            sacrificeCanvas.enabled = !sacrificeCanvas.enabled;
        }
    }

    public void BlindEye(string layer)
    {
        sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer(layer));
        Debug.Log("Culled" + layer);
    }
}
