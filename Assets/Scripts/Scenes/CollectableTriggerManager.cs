using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectableTriggerManager : MonoBehaviour
{
    [SerializeField] private List<ItemTrigger> itemTriggers;
    [SerializeField] private Animator animator;
    [SerializeField] private string attributeName;
    [SerializeField] private AudioClip audioClip;
    private bool doorOpen;

    private void Start()
    {
        itemTriggers = FindObjectsOfType<ItemTrigger>().ToList();
    }

    public void CheckItemTriggers()
    {
        bool requirementMet = true;
        foreach (ItemTrigger itemTrigger in itemTriggers)
        {
            if (!itemTrigger.requirementComplete)
            {
                requirementMet = false;
            }
        }

        if (requirementMet && !doorOpen)
        {
            animator.SetBool(attributeName, true);
            if (audioClip)
                animator.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
            doorOpen = true;
        }
    }
}
