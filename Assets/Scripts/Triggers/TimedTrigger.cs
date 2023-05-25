using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool desiredState;
    [SerializeField] private float secondsUntilEvent;

    private void Start() {
        if(animator == null)
            animator = GetComponent<Animator>();
        Invoke("ExecuteEvent", secondsUntilEvent);
    }

    private void ExecuteEvent() {
        if(animator.GetBool(parameterName) != desiredState)
        animator.SetBool(parameterName, desiredState);
    }
}
