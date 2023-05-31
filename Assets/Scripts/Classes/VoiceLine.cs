using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceLine
{
    public string audioName;
    public AudioClip audioClip;
    public float audioDelay;
    public string faceParameterName;
    public float faceStartDelay;
    public float faceEndDelay;
}
