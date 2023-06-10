using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private float delay;
    [SerializeField] private bool worksOnce;
    [SerializeField] private AudioClip clip;
    private GameObject player;
    private bool toggled;

    private void Start() {
        if (source == null)
            source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            if (!toggled) {
                Invoke("execute", delay);
            }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            if (worksOnce) { 
                toggled = true;
            }

        }
    }

    private void execute() {
        source.PlayOneShot(clip);
    }
}
