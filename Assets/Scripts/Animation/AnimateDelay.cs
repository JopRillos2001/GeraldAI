using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDelay : MonoBehaviour
{
    [SerializeField] private string parameterName;
    [SerializeField] private float delay;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        Invoke("StartAnim", delay);
    }

    private void StartAnim() {
        animator.SetBool(parameterName, true);
    }
}
