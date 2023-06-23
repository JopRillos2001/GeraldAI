using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]  
public class RespawnItemTrigger : MonoBehaviour
{
    [SerializeField] private float respawnDelay;
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<RespawnItem>()) {

            StartCoroutine(RespawnItem(other.GetComponent<RespawnItem>()));
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<RespawnItem>()) {

            other.GetComponent<RespawnItem>().respawning = false;
        }
    }

    private IEnumerator RespawnItem(RespawnItem respawnItem) {
        respawnItem.respawning = true;
        yield return new WaitForSeconds(2);
        if(respawnItem.respawning)
        respawnItem.resetItem();
    }
}
