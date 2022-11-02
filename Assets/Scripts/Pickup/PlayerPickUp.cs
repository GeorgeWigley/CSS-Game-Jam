using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MatrixToggle
{
    [SerializeField] private Transform cam;
    [SerializeField] private Vector3 boxSize = Vector3.one;
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
            Collider[] pickupColliders = Physics.OverlapBox(GetBoxCenter(), boxSize, transform.rotation, pickUpMask);
            IPickup closest = null;
            Transform closestTransform = null;
            float closestDistance = float.MaxValue;
            foreach (Collider col in pickupColliders)
            {
                if (col.transform.TryGetComponent(out IPickup pickup))
                {
                    float dst = (col.transform.position - transform.position).sqrMagnitude;
                    if (dst < closestDistance)
                    {
                        closest = pickup;
                        closestDistance = dst;
                        closestTransform = col.transform;
                    }
                }
            }

            if (closest != null)
            {
                StartCoroutine(Pickup(closest, closestTransform));
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

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(GetBoxCenter(), boxSize);
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