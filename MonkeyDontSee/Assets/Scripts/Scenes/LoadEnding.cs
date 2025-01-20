using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadEnding : MonoBehaviour
{
    private bool _isNear;

    [SerializeField] private GameObject templeText;

    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject sacrificePanel;
    [SerializeField] private GameObject panel;

    void Start()
    {
        templeText.GetComponent<TextMeshPro>().text = "";
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNear = true;
            templeText.GetComponent<TextMeshPro>().text = "Press E to climb the temple.";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNear = false;
            templeText.GetComponent<TextMeshPro>().text = "";
        }
    }

    void Update()
    {
        if ( _isNear && Input.GetKeyDown(KeyCode.E))
        {
            canvas.enabled = true;
            sacrificePanel.SetActive(false);
            panel.SetActive(true);
            panel.GetComponent<TransitionPanelAnimator>().FadeOut();
        }
    }
}
