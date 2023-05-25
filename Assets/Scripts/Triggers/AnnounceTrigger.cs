using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnnounceTrigger : MonoBehaviour
{
    [SerializeField] private List<SoundClip> clips;
    private AudioClip clipToPlay;

    private void Start() {
        foreach (SoundClip clip in clips) {
            clipToPlay = clip.clip;
            Invoke("PlayClip", clip.delay);
        }
    }

    private void PlayClip() {
        GetComponent<AudioSource>().PlayOneShot(clipToPlay);
    }
}
