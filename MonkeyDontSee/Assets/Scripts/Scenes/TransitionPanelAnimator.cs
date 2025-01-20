using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPanelAnimator : MonoBehaviour
{
    [SerializeField] private Animator panelAnimator;

    [SerializeField] private string sceneToLoad;

    void Start()
    {
        panelAnimator = GetComponent<Animator>();
    }

    public void FadeOut()
    {
        panelAnimator.SetTrigger("FadeOUT");
    }

    public void FadeIn()
    {
        panelAnimator.SetTrigger("FadeIN");
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

}
