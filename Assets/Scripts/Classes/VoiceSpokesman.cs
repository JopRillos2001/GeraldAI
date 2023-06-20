using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceSpokesman
{
    public string npcName;
    public Animator faceAnimator;
    public Transform bubble;
    public List<VoiceLine> voiceLines;
    public List<VoiceBubble> voiceBubbles;
}
