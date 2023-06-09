using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private float delay;
    [SerializeField] private bool desiredState;
    [SerializeField] private bool openAndClose;
    [SerializeField] private bool worksOnce;
    private GameObject player;
    private bool toggled;
    [SerializeField] private bool playSound;
    [SerializeField] private AudioClip clipTrue;
    [SerializeField] private AudioClip clipFalse;

    private void Start() {
        if (animator == null)
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            Invoke("execute", delay);
            
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
        if (openAndClose && !toggled) {
            animator.SetBool(parameterName, !animator.GetBool(parameterName));
            if (!playSound) return;
            if (animator.GetBool(parameterName) == true && clipTrue != null) {
                animator.GetComponent<AudioSource>().PlayOneShot(clipTrue);
            } else if (animator.GetBool(parameterName) == false && clipFalse != null) {
                animator.GetComponent<AudioSource>().PlayOneShot(clipFalse);
            }
        } else {
            if (animator.GetBool(parameterName) != desiredState) {
                animator.SetBool(parameterName, desiredState);
                if (!playSound) return;
                if (animator.GetBool(parameterName) == true && clipTrue != null) {
                    animator.GetComponent<AudioSource>().PlayOneShot(clipTrue);
                } else if (animator.GetBool(parameterName) == false && clipFalse != null) {
                    animator.GetComponent<AudioSource>().PlayOneShot(clipFalse);
                }
            }
        }
    }
}
