using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnnounceTrigger : MonoBehaviour
{
    [SerializeField] private List<SoundClip> clips;

    private void Start() {
        foreach (SoundClip clip in clips) {
            StartCoroutine(PlayClip(clip.clip, clip.delay));
        }
    }

    private IEnumerator PlayClip(AudioClip clip, float delay) {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
