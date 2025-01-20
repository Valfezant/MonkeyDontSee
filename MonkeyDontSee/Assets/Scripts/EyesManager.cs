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

    [Header("Altars")]
    [SerializeField] private bool _usedAltar;
    public Transform lastAltarTransform;

    //canvases
    [Header("Canvas")]
    [SerializeField] private Canvas sacrificeCanvas; 
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI offerText;
    [SerializeField] private Button sacrificeButton;
    [SerializeField] private GameObject giveUpPanel;

    //Events
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    public static event ClickAction onPlayerGiveUp;
    
    void Start()
    {
        sacrificeCanvas.enabled = false;
        StartCoroutine(EnableEyes());

        currentSacrificeCost = baseSacrificeCost;

        _usedAltar = false;

        giveUpPanel.SetActive(false);
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
        if (!_usedAltar)
        {
            sacrificeCanvas.enabled = true;
            offerValue = 0;
            costText.text = "Requested cost: " + currentSacrificeCost;
            sacrificeButton.interactable = false;
        }
        else
        {
            var respawnScript = GameObject.FindWithTag("Manager").GetComponent<RespawnPlayer>();
            respawnScript.ResurrectPlayer();
            _usedAltar = false;
        }
    }

    public void BlindEye(string layer)
    {
        sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer(layer));
        Debug.Log("Culled" + layer);
    }

    public void RandomEye()
    {
        var randomEye = eyesArray[Random.Range(0, eyesArray.Length)];
        Debug.Log(randomEye);

        if (randomEye._canSee)
        {
            BlindEye(randomEye.colorLayerName);
            randomEye._canSee = false;
        }
        else
        {
            RandomEye();
        }

        _usedAltar = true;
    }

    void Update()
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.X))
        {
           SacrificeScreen();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
           PlayerGiveUp();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            giveUpPanel.SetActive(false);
        }

        offerText.text = "Current offer: " + offerValue;

        //check is price is met
        if (offerValue >= currentSacrificeCost)
        {
            sacrificeButton.interactable = true;
        }
    }

    //On "Sacrifice!" button
    public void PerformSacrifice()
    {
        if (OnClicked != null)
        {
            OnClicked();
        }

        //Find respawn script, proceed with resurrection
        var respawnScript = GameObject.FindWithTag("Manager").GetComponent<RespawnPlayer>();
        respawnScript.ResurrectPlayer();

        //Hide canvas
        sacrificeCanvas.enabled = false;
        sacrificeButton.interactable = false;

        //Update price
        currentSacrificeCost *= 2;
    }

    //GIVE UP
    public void ShowGiveUpPanel()
    {
        giveUpPanel.SetActive(true);
    }
    
    public void PlayerGiveUp()
    {
        if (onPlayerGiveUp != null)
        {
            onPlayerGiveUp();
        }

        StartCoroutine(EnableEyes());
        sceneCamera.cullingMask = -1;

        currentSacrificeCost = baseSacrificeCost;

        if (lastAltarTransform != null)
        {
            var player = GameObject.FindWithTag("Player");
            player.transform.position = lastAltarTransform.position;
        }

        giveUpPanel.SetActive(false);
        sacrificeCanvas.enabled = false;
    }

    //QUIT
    public void QuitGame()
    {
        Application.Quit();
    }
}
