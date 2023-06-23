using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  
public class RespawnItem : MonoBehaviour
{
    private Vector3 spawnLocation;
    private Quaternion spawnRotation;
    private Rigidbody rb;
    public bool respawning;
    [SerializeField] private float minYLevel = -190;
    private void Start() {
        spawnLocation = transform.position;
        spawnRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (transform.position.y < minYLevel) {
            resetItem();
        }
    }

    public void resetItem() {
        respawning = false;
        rb.velocity = Vector3.zero;
        transform.position = spawnLocation;
        transform.rotation = spawnRotation;
    }
}
