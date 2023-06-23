using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private AllDirtCollectedTrigger triggerManager;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();


        if(playerInventory != null)
        {
            playerInventory.DirtCollected();
            AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
            gameObject.SetActive(false);
            if(playerInventory.NumberOfDirt == 17)
            {
                triggerManager.DirtCollected();
            }
        }

    }
}
