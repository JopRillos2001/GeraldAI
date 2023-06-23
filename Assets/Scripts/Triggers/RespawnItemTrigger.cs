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

    private IEnumerator RespawnItem(RespawnItem respawnItem) {
        yield return new WaitForSeconds(2);
        respawnItem.resetItem();
    }
}
