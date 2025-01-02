using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesButtons : MonoBehaviour
{
    [SerializeField] public Eye thisEye;
    [SerializeField] private EyesManager eyesManager;

    public void ChooseEye()
    {
        eyesManager.BlindEye(thisEye.colorLayerName);
        var sprite = GetComponent<RawImage>();
        sprite.color = Color.black;
        GetComponent<Button>().interactable = false;
        thisEye._canSee = false;

        StartResurrection();
    }

    private void StartResurrection()
    {
        var respawnScript = GameObject.FindWithTag("Manager").GetComponent<RespawnPlayer>();
        respawnScript.ResurrectPlayer();
    }
}
