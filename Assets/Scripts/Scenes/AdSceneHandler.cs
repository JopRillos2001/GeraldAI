using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdSceneHandler : MonoBehaviour
{
    [SerializeField] private Animator lightAnimator;
    [SerializeField] private float delay = 5f;

    private void Start() {
        Invoke("DimLight", delay);
    }

    private void DimLight() {
        lightAnimator.SetBool("Dim", true);
    }
}
