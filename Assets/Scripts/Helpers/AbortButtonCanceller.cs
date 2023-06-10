using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbortButtonCanceller : MonoBehaviour
{
    [SerializeField] private AbortButton abortButton;
    [SerializeField] private float predelay;
    [SerializeField] private float delay;
    [SerializeField] private bool worksOnce;
    private GameObject player;
    private bool toggled;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            if (!toggled)
                abortButton.disabled = true;
                Invoke("allowAbortButton", predelay);
                Invoke("cancelAbortButton", delay);

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            if (worksOnce) {
                toggled = true;
            }

        }
    }
    private void allowAbortButton() {
        abortButton.disabled = false;
    }
    private void cancelAbortButton() {
        abortButton.disabled = true;
    }
}
