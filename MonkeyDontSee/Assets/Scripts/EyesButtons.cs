using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesButtons : MonoBehaviour
{
    [SerializeField] public Eye thisEye;
    [SerializeField] private EyesManager eyesManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseEye()
    {
        eyesManager.BlindEye(thisEye.colorLayerName);
        var sprite = GetComponent<RawImage>();
        sprite.color = Color.black;
        GetComponent<Button>().interactable = false;
    }
}
