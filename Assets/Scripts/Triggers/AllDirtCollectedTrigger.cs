using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDirtCollectedTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool playSound;
    [SerializeField] private AudioClip clipTrue;
    [SerializeField] private AudioClip clipFalse;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

    }

    public void DirtCollected()
    {
        Invoke("ExecuteEvent",5);
    }

    private void ExecuteEvent()
    {        
            animator.SetTrigger(parameterName);
            if (!playSound) return;
            if (animator.GetBool(parameterName) == true && clipTrue != null)
            {
                GetComponent<AudioSource>().PlayOneShot(clipTrue);
            }
        
    }
    
}
