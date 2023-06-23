using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInDisabler : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private bool desiredState;
    [SerializeField] private float delay;
    private GameObject player;
    private bool toggled;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            if (!toggled)
                Invoke("execute", delay);
        }
    }

    private void execute() {
        objectToDisable.SetActive(desiredState);
    }
}
