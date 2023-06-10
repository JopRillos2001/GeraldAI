using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractTrigger : MonoBehaviour 
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool desiredState;
    [SerializeField] private bool openAndClose;
    [SerializeField] private bool worksOnce;
    private GameObject player;
    private bool toggled;
    private bool releaseToggle;
    [SerializeField] private bool playSound;
    [SerializeField] private AudioClip clipTrue;
    [SerializeField] private AudioClip clipFalse;

    private void Start() {
        if (animator == null)
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject == player && player.GetComponent<StarterAssets.GeraldController>().getInteract() && !releaseToggle) {
            if (!toggled) {
                if (worksOnce) {
                    toggled = true;
                }
                GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.Interact);
                releaseToggle = true;
                if (openAndClose) {
                    animator.SetBool(parameterName, !animator.GetBool(parameterName));
                } else {
                    if (animator.GetBool(parameterName) != desiredState) {
                        animator.SetBool(parameterName, desiredState);
                    }
                }
                if (!playSound) return;
                if (animator.GetBool(parameterName) == true && clipTrue != null) {
                    GetComponent<AudioSource>().PlayOneShot(clipTrue);
                } else if (animator.GetBool(parameterName) == false && clipFalse != null) {
                    GetComponent<AudioSource>().PlayOneShot(clipFalse);
                }
            }
        }
        if (!player.GetComponent<StarterAssets.GeraldController>().getInteract()) {
            releaseToggle = false;
            
        }
    }
}
