using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesButtons : MonoBehaviour
{
    [SerializeField] public Eye thisEye;
    [SerializeField] private EyesManager eyesManager;

    private bool _eyeSelected;

    void Start()
    {
        _eyeSelected = false;
    }

    //On "eye" buttons
    public void ChooseEye()
    {
        if (!_eyeSelected)
        {
            //offer
            var sprite = GetComponent<RawImage>();
            sprite.color = Color.blue;

            EyesManager.OnClicked += EyeOffered;

            eyesManager.offerValue += thisEye.eyeValue;

            _eyeSelected = true;
        }
        else
        {
            //restore
            var sprite = GetComponent<RawImage>();
            sprite.color = Color.white;

            EyesManager.OnClicked -= EyeOffered;

            eyesManager.offerValue -= thisEye.eyeValue;

            _eyeSelected = false;
        }
    }

    private void EyeOffered()
    {
        eyesManager.BlindEye(thisEye.colorLayerName);
        GetComponent<Button>().interactable = false;
        thisEye._canSee = false;
    }

    void Update()
    {
        
    }

    void OnEnabled()
    {
        if (!thisEye._canSee)
        {
            var sprite = GetComponent<RawImage>();
            sprite.color = Color.red;
            GetComponent<Button>().interactable = false;
        }
        else
        {
            var sprite = GetComponent<RawImage>();
            sprite.color = Color.white;
            GetComponent<Button>().interactable = true;
        }
    }


    //--Nuovo bottone--
    //--valore sugli SO--
    //--ricorda occhio scelto, rimuovi dopo--
    //--check cost raggiunto--
    //--indicatore costo--
    //--valore costo, counter sacrifici (costo * 2?)--
    //sacrifici stored da altare

}
