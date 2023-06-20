using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceBubble
{
    [TextArea]
    public string voiceText;
    public float bubbleStartDelay;
    public float bubbleLength;
}
