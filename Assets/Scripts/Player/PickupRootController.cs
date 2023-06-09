using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRootController : MonoBehaviour {
    private GeraldInputs _input;
    [SerializeField] private LayerMask PickupMask;
    private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupDistance;
    [SerializeField] private Rigidbody CurrentObject;
    private bool pickupToggleCheck;
    private bool dropToggleCheck;

    private void Start() {
        PlayerCamera = Camera.main;
        _input = GetComponent<GeraldInputs>();
    }

    private void Update() {
        Pickup();
        Drop();        
    }

    private void FixedUpdate() {
        if (CurrentObject) {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }        
    }    

    private void Pickup() {
        if (_input.pickup && !pickupToggleCheck) {
            print("Button pressed");
            pickupToggleCheck = true;
            if (CurrentObject) return;
            print("Object confirmed");
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupDistance, PickupMask)) {
                print("Object correct");
                GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.PickUpItems);
                CurrentObject = HitInfo.rigidbody;
                if(CurrentObject.gameObject.layer == 8) CurrentObject.gameObject.layer = 10;
                if(CurrentObject.gameObject.layer == 9) CurrentObject.gameObject.layer = 11;
                CurrentObject.useGravity = false;
            }
        }
        if (!_input.pickup && pickupToggleCheck)
            pickupToggleCheck = false;
    }

    private void Drop() {
        if (_input.drop && !dropToggleCheck) {
            dropToggleCheck = true;
            if (CurrentObject) {
                GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.DropItems);
                if (CurrentObject.gameObject.layer == 10) CurrentObject.gameObject.layer = 8;
                if (CurrentObject.gameObject.layer == 11) CurrentObject.gameObject.layer = 9;
                CurrentObject.useGravity = true;
                if (CurrentObject.velocity.magnitude > 10) {
                    GameManager.Instance.GetComponent<ProgressManager>().DiscoverMechanic(MechanicEnum.Throw);
                }
                GameObject.FindGameObjectWithTag("Player").GetComponent<GeraldController>().LastPickupItem = CurrentObject.GetComponent<PickupItem>();
                CurrentObject = null;
                return;
            }
        }
        if (!_input.drop && dropToggleCheck)
            dropToggleCheck = false;
    }

}
