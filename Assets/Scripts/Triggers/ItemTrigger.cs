using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public bool requirementComplete = false;
    private int itemsInTrigger;
    [SerializeField] private CollectableTriggerManager triggerManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable") itemsInTrigger++;
        if (itemsInTrigger > 0) requirementComplete = true;
        triggerManager.CheckItemTriggers();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable") itemsInTrigger--;
        if (itemsInTrigger == 0) requirementComplete = false;
        triggerManager.CheckItemTriggers();
    }
}
