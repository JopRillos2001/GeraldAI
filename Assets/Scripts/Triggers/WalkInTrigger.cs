using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool desiredState;
    [SerializeField] private bool openAndClose;
    private GameObject player;
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
            if (openAndClose) {
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
}
