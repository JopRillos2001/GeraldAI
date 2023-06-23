using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public bool requirementComplete = false;
    private int itemsInTrigger;
    [SerializeField] private int amountNeeded = 1;
    [SerializeField] private CollectableTriggerManager triggerManager;
    [SerializeField] private int groupId;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable") itemsInTrigger++;
        if (itemsInTrigger >= amountNeeded) requirementComplete = true;
        triggerManager.CheckItemTriggers(groupId);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable") itemsInTrigger--;
        if (itemsInTrigger < amountNeeded) requirementComplete = false;
        triggerManager.CheckItemTriggers(groupId);
    }

    public int getAmountNeeded() {
        return amountNeeded;
    }

    public int getAmountInTrigger() {
        return itemsInTrigger;
    }
}
