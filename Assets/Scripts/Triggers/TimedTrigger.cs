using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool desiredState;
    [SerializeField] private float secondsUntilEvent;
    [SerializeField] private bool playSound;
    [SerializeField] private AudioClip clipTrue;
    [SerializeField] private AudioClip clipFalse;

    private void Start() {
        if(animator == null)
            animator = GetComponent<Animator>();
        Invoke("ExecuteEvent", secondsUntilEvent);
    }

    private void ExecuteEvent() {
        if (animator.GetBool(parameterName) != desiredState) {
            animator.SetBool(parameterName, desiredState);
            if (!playSound) return;
            if (animator.GetBool(parameterName) == true && clipTrue != null) {
                GetComponent<AudioSource>().PlayOneShot(clipTrue);
            } else if (animator.GetBool(parameterName) == false && clipFalse != null) {
                    GetComponent<AudioSource>().PlayOneShot(clipFalse);
            }
        }
    }
}
