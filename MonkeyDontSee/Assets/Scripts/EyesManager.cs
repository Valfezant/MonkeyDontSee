using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyesManager : MonoBehaviour
{
    [SerializeField] private Camera sceneCamera;

    [SerializeField] public Eye[] eyesArray;

    [SerializeField] private int baseSacrificeCost;
    private int currentSacrificeCost;
    public int offerValue;

    //canvases
    [SerializeField] private Canvas sacrificeCanvas; 
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button sacrificeButton;
    
    void Start()
    {
        sacrificeCanvas.enabled = false;
        StartCoroutine(EnableEyes());

        currentSacrificeCost = baseSacrificeCost;
    }

    IEnumerator EnableEyes()
    {
        foreach (Eye eye in eyesArray)
        {
            eye._canSee = true;

            yield return new WaitForSeconds(0);
        }
    }

    public void SacrificeScreen()
    {
        sacrificeCanvas.enabled = true;
        costText.text = "Requested cost: " + currentSacrificeCost;
        sacrificeButton.interactable = false;
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

    void Update()
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.X))
        {
            sacrificeCanvas.enabled = !sacrificeCanvas.enabled;
        }

        //check is price is met
        if (offerValue >= currentSacrificeCost)
        {
            sacrificeButton.interactable = true;
        }
    }

    public void PerformSacrifice()
    {
        

        //Find respawn script, proceed with resurrection
        var respawnScript = GameObject.FindWithTag("Manager").GetComponent<RespawnPlayer>();
        respawnScript.ResurrectPlayer();

        //Hide canvas
        sacrificeCanvas.enabled = false;
        sacrificeButton.interactable = false;

        //Update price
        currentSacrificeCost *= 2;
    }
}
