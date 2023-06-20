using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NPCTrigger : MonoBehaviour
{
    public VoiceSpokesman voiceSpokesman;
    private bool talked;

    private void Update() {
        voiceSpokesman.bubble.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        if (!talked && voiceSpokesman.voiceLines != null) { 
            talked = true;
            List<VoiceLine> voiceLines = voiceSpokesman.voiceLines;
            List<VoiceBubble> voiceBubbles = voiceSpokesman.voiceBubbles;
            foreach (VoiceLine voiceLine in voiceLines) {
                StartCoroutine(PlayClip(voiceLine));
                StartCoroutine(PlayFaceAnim(voiceLine));
            }
            int vbCur = 0;
            foreach (VoiceBubble voiceBubble in voiceBubbles) {
                vbCur++;
                if(vbCur >= voiceBubbles.Count)
                    StartCoroutine(VoiceBubbleHandle(voiceBubble, voiceSpokesman.bubble, true));
                else
                    StartCoroutine(VoiceBubbleHandle(voiceBubble, voiceSpokesman.bubble, false));
            }
        }
    }

    private IEnumerator PlayClip(VoiceLine vl) {
        yield return new WaitForSeconds(vl.audioDelay);
        GetComponent<AudioSource>().PlayOneShot(vl.audioClip);
    }

    private IEnumerator PlayFaceAnim(VoiceLine vl) {
        yield return new WaitForSeconds(vl.faceStartDelay);
        if (voiceSpokesman.faceAnimator.GetBool(vl.faceParameterName) != true) {
            voiceSpokesman.faceAnimator.SetBool(vl.faceParameterName, true);
        }
        yield return new WaitForSeconds(vl.faceLength);
        if (voiceSpokesman.faceAnimator.GetBool(vl.faceParameterName) != false) {
            voiceSpokesman.faceAnimator.SetBool(vl.faceParameterName, false);
        }
    }

    private IEnumerator VoiceBubbleHandle(VoiceBubble vb, Transform b, bool final) {
        yield return new WaitForSeconds(vb.bubbleStartDelay);
        b.gameObject.SetActive(true);
        b.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = vb.voiceText;
        yield return new WaitForSeconds(vb.bubbleLength + 0.5f);
        if (final) {
            b.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "";
            b.gameObject.SetActive(false);
            talked = false;
        }
    }
}
