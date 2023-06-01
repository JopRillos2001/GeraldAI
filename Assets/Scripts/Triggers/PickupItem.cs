using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupItem : MonoBehaviour
{
    private Rigidbody rb;
    public float GroundedOffset = 0.5f; 
    public float GroundedRadius = 0.5f;
    public LayerMask GroundLayers = 1; 
    public bool Grounded = true;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "ConveyorBelt") {
            rb.AddForce(collision.transform.forward * 10);
        }
    }

    private void Update() {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
    }
}
