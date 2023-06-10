using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbortButtonCanceller : MonoBehaviour
{
    [SerializeField] private AbortButton abortButton;
    [SerializeField] private float predelay;
    [SerializeField] private float delay;

    private void Start() {
        abortButton.disabled = true;
        Invoke("allowAbortButton", predelay);
        Invoke("cancelAbortButton", delay);
    }
    private void allowAbortButton() {
        abortButton.disabled = false;
    }
    private void cancelAbortButton() {
        abortButton.disabled = true;
    }
}
