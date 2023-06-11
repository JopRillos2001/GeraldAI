using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimDir : MonoBehaviour
{
    [SerializeField] private string parameterName;
    [SerializeField] private int intParam;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetInteger(parameterName, intParam);
    }
}
