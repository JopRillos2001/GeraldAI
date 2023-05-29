using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupItem : MonoBehaviour
{
    private Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "ConveyorBelt") {
            rb.AddForce(collision.transform.forward * 10);
        }
    }
}
