using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //Panels
    [SerializeField] private GameObject titlePanel;
    [SerializeField] private GameObject storyPanel;
    
    //Story
    [Header("Story Text")]
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] [TextArea(3,10)] private string story;
    [SerializeField] private float textSpeed;

    [Header("Story Images")]
    [SerializeField] private GameObject[] storyImages;
    [SerializeField] private float imageSpeed;

    void Start()
    {
        titlePanel.SetActive(true);
        storyPanel.SetActive(false);
    }

    public void StartStory()
    {
        titlePanel.SetActive(false);
        storyPanel.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(TypeStory());
        StartCoroutine(ShowImages());
    }

    private IEnumerator TypeStory()
    {
        storyText.text = "";
        foreach (char letter in story.ToCharArray())
        {
            if (Input.GetMouseButton(0))
            {
                storyText.text = story;
                break;
            }
            
            //textSound.CurrentChar++;
            //textSound.PlayTextSound();

            storyText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private IEnumerator ShowImages()
    {
        foreach (GameObject image in storyImages)
        {
            if (Input.GetMouseButton(0))
            {
                storyImages[0].SetActive(true);
                storyImages[1].SetActive(true);
                storyImages[2].SetActive(true);
                Debug.Log("imag");
                break;
            }

            image.SetActive(true);
            yield return new WaitForSeconds(imageSpeed);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1_Level Scene", LoadSceneMode.Single);
    }
}
