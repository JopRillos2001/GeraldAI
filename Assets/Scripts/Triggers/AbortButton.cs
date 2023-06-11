using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbortButton : MonoBehaviour
{
    [SerializeField] private Animator squasherAnimator;
    [SerializeField] private string parameterName;
    [SerializeField] private bool worksOnce;
    public bool disabled;
    private GameObject player;
    private bool toggled;
    private bool releaseToggle;
    [SerializeField] private bool playSound;
    [SerializeField] private AudioClip clipTrue;
    [SerializeField] private AudioClip clipFalse;

    [SerializeField] private GameObject escapeBlocker;
    [SerializeField] private BoxCollider continueDoor;
    [SerializeField] private Animator alarmPanel;
    [SerializeField] private BoxCollider continueTrigger;
    [SerializeField] private BoxCollider saveTrigger;

    private void Start() {
        if (squasherAnimator == null)
            squasherAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        continueTrigger.enabled = true;
        saveTrigger.enabled = false;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject == player && player.GetComponent<StarterAssets.GeraldController>().getInteract() && !releaseToggle) {
            GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.Interact);
            releaseToggle = true;
            if (!toggled && !disabled) {
                if (worksOnce) {
                    toggled = true;
                }
                stopSquasher();
            }
            if (!playSound) return;
            if (toggled || disabled) {
                GetComponent<AudioSource>().PlayOneShot(clipFalse);
            } else
            if (squasherAnimator.GetBool(parameterName) == true && clipTrue != null) {
                GetComponent<AudioSource>().PlayOneShot(clipTrue);
            } else if (squasherAnimator.GetBool(parameterName) == false && clipFalse != null) {
                GetComponent<AudioSource>().PlayOneShot(clipFalse);
            }
        }
        if (!player.GetComponent<StarterAssets.GeraldController>().getInteract()) {
            releaseToggle = false;
            
        }
    }

    private void stopSquasher() {
        squasherAnimator.SetBool(parameterName, false);
        escapeBlocker.SetActive(true);
        continueDoor.enabled = false;
        alarmPanel.SetBool("Alarm", true);
        continueTrigger.enabled = false;
        saveTrigger.enabled = true;
        Invoke("disableAlarmPanel", 10);
    }

    private void disableAlarmPanel() {
        alarmPanel.SetBool("Alarm", false);
    }

}
