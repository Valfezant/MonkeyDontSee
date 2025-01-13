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
            var image = GetComponent<Image>();
            image.sprite = thisEye.eyeClosed;

            EyesManager.OnClicked += EyeOffered;

            eyesManager.offerValue += thisEye.eyeValue;

            _eyeSelected = true;
        }
        else
        {
            //restore
            var image = GetComponent<Image>();
            image.sprite = thisEye.eyeOpen;

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

        //Change sprite
        var image = GetComponent<Image>();
        image.sprite = thisEye.eyeScar;
    }

    void Update()
    {
        
    }

    void OnEnabled()
    {
        if (!thisEye._canSee)
        {
            /*var sprite = GetComponent<Image>();
            sprite = thisEye.eyeScar;*/
            GetComponent<Button>().interactable = false;
        }
        else
        {
            /*var sprite = GetComponent<Image>();
            sprite = thisEye.eyeOpen;*/
            GetComponent<Button>().interactable = true;
        }
    }
}
