using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectableTriggerManager : MonoBehaviour
{
    [SerializeField] private List<CollectableCheckClass> collectibleChecks;

    public void CheckItemTriggers(int groupId)
    {
        bool requirementMet = true;
        foreach (ItemTrigger itemTrigger in collectibleChecks[groupId].itemTriggers)
        {
            if (!itemTrigger.requirementComplete)
            {
                requirementMet = false;
            }
        }

        if (requirementMet && !collectibleChecks[groupId].completed)
        {
            collectibleChecks[groupId].animator.SetBool(collectibleChecks[groupId].attributeName, true);
            if (collectibleChecks[groupId].audioClip)
                collectibleChecks[groupId].animator.gameObject.GetComponent<AudioSource>().PlayOneShot(collectibleChecks[groupId].audioClip);
            collectibleChecks[groupId].completed = true;
        }
    }
}
