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
        StartCoroutine(EnableEyes());
    }

    IEnumerator EnableEyes()
    {
        foreach (Eye eye in eyesArray)
        {
            eye._canSee = true;

            yield return new WaitForSeconds(0);
        }
    }

    void Update()
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.X))
        {
            sacrificeCanvas.enabled = !sacrificeCanvas.enabled;
        }
    }

    public void SacrificeScreen()
    {
        sacrificeCanvas.enabled = true;
    }

    public void BlindEye(string layer)
    {
        sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer(layer));
        Debug.Log("Culled" + layer);
    }

    public void RandomEye()
    {
        var randomEye = eyesArray[Random.Range(0, eyesArray.Length)];

        if (randomEye._canSee)
        {
            BlindEye(randomEye.colorLayerName);
            randomEye._canSee = false;
        }
        else
        {
            RandomEye();
        }
    }
}
