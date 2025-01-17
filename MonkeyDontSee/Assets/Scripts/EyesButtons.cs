using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EyesButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Eye thisEye;
    [SerializeField] private EyesManager eyesManager;

    private bool _eyeSelected;

    //Tooltips
    [SerializeField] public RectTransform tooltipBg;
    [SerializeField] public TextMeshProUGUI tooltipText;

    void Start()
    {
        _eyeSelected = false;

        HideTooltip();
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

    //SHOWING TOOLTIP
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }

    private void ShowTooltip()
    {
        tooltipText.text = thisEye.eyeDescription;

        //tooltipBg.sizeDelta = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight > 500 ? 500 : tooltipText.preferredHeight);
        tooltipBg.gameObject.SetActive(true);
        tooltipBg.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + 100);
    }

    private void HideTooltip()
    {
        tooltipText.text = "";
        tooltipBg.gameObject.SetActive(false);
    }
}
