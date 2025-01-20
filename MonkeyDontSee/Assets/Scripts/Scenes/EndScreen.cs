using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] [TextArea(1, 10)] private string endingStory;
    public int endingIndex;

    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private float endTextSpeed;

    void Start()
    {
        //endText.text = "";
        endingIndex = 0;

        StartCoroutine(TypeEnding());
    }

    /*private IEnumerator TypeEnding()
    {
        //endText.text = "";
        foreach (char letter in endingStory[endingIndex])
        {
            if (Input.GetMouseButton(0))
            {            
                endText[endingIndex].text = endingStory[endingIndex];
                endingIndex++;
                break;
            }

            endText[endingIndex].text += letter;
            yield return new WaitForSeconds(endTextSpeed);
        }

        endingIndex++;
        yield return new WaitForSeconds(0);
    }*/

    private IEnumerator TypeEnding()
    {
        foreach (char letter in endingStory)
        {
            if (Input.GetMouseButton(0))
            {            
                endText.text = endingStory;
                break;
            }

            endText.text += letter;
            yield return new WaitForSeconds(endTextSpeed);
        }

        yield return new WaitForSeconds(0);
    }

    void Update()
    {
        /*if (Input.GetMouseButton(0) && !_skippingDialogue)
        {
            _skippingDialogue = true;
            
            if (endingIndex <= endingStory.Length)
            {
                StopAllCoroutines();
                endText[endingIndex].text = endingStory[endingIndex];
                endingIndex++;
                StartCoroutine(TypeEnding());
            }
        }

        _skippingDialogue = false;

        /*if (endingIndex <= endingStory.Length && !_textStarted)
        {
            _textStarted = true;
            StartCoroutine(TypeEnding());
        }*/

    }
}
