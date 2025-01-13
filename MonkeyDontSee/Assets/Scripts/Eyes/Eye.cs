using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Eye", menuName = "Eye")]
public class Eye : ScriptableObject
{
    public string eyeName;
    
    [TextArea(1,5)] public string eyeDescription;
    
    public int eyeValue;

    public string colorLayerName;

    public bool _canSee;

    public Sprite eyeOpen;
    public Sprite eyeClosed;
    public Sprite eyeScar;
}
