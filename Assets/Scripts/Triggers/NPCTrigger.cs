using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NPCTrigger : MonoBehaviour
{
    public VoiceSpokesman voiceSpokesman;
    private bool talked;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        if (!talked && voiceSpokesman.voiceLines != null) { 
            talked = true;
            List<VoiceLine> voiceLines = voiceSpokesman.voiceLines;
            foreach (VoiceLine voiceLine in voiceLines) {
                StartCoroutine(PlayClip(voiceLine));
                StartCoroutine(PlayFaceAnim(voiceLine));
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
        yield return new WaitForSeconds(vl.faceEndDelay);
        if (voiceSpokesman.faceAnimator.GetBool(vl.faceParameterName) != false) {
            voiceSpokesman.faceAnimator.SetBool(vl.faceParameterName, false);
        }
    }
}
