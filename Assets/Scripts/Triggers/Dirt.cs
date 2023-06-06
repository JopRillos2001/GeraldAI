using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private AllDirtCollectedTrigger triggerManager;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();


        if(playerInventory != null)
        {
            playerInventory.DirtCollected();
            gameObject.SetActive(false);
            if(playerInventory.NumberOfDirt == 16)
            {
                triggerManager.DirtCollected();
            }
        }

    }
}
