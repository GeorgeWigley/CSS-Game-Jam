using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MatrixToggle
{
    [SerializeField] private Transform cam;
    [SerializeField] private float pickupDistance = 3;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask pickUpMask;

    private IPickup holding;
    private bool inMatrix;

    private void Update()
    {
        if (!inMatrix && holding != null) {
            holding.OnDrop();
            holding = null;
            return;
        }
        if (holding == null && Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.SphereCast(transform.position, 0.5f, cam.forward, out RaycastHit hit, pickupDistance, pickUpMask))
            {
                print(hit.transform);
                if (hit.transform.TryGetComponent(out IPickup pickup))
                {
                    StartCoroutine(Pickup(pickup, hit.transform));
                }
            }
        }
    }

    private IEnumerator Pickup(IPickup pickup, Transform pickupTransform)
    {
        Debug.Log("Pickup Start");
        Debug.Log(inMatrix);
        if (inMatrix) {
            Debug.Log("Enter pickup");
            pickup.OnPickup();
            holding = pickup;
            yield return null;
            while (!Input.GetKeyDown(KeyCode.E) && inMatrix && holding != null && pickupTransform != null)
            {
                pickupTransform.position = GetBoxCenter();
                yield return null;
            }
            if (pickup != null) {
                pickup.OnDrop();
            }
            Debug.Log("Dropped");
            yield return null;
            holding = null;
        }
    }

    private Vector3 GetBoxCenter()
    {
        return transform.position + cam.TransformDirection(offset);
    }

    public override void EnterMatrixView()
    {
        inMatrix = true;
    }

    public override void ExitMatrixView()
    {
        inMatrix = false;
    }

}

public interface IPickup
{
    void OnPickup();
    void OnDrop();
}