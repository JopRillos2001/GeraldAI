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
    private GameObject player;
    private bool releaseToggle;

    private void Start() {
        if (animator == null)
            animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject == player && player.GetComponent<StarterAssets.FirstPersonController>().getInteract() && !releaseToggle) {
            GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.Interact);
            releaseToggle = true;
            if (openAndClose) {
                animator.SetBool(parameterName, !animator.GetBool(parameterName));
            } else {
                if (animator.GetBool(parameterName) != desiredState)
                    animator.SetBool(parameterName, desiredState);
            }
        }
        if (!player.GetComponent<StarterAssets.FirstPersonController>().getInteract()) {
            releaseToggle = false;
        }
    }
}
