using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Vector3 boxSize = Vector3.one;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask pickUpMask;

    private bool holding;

    private void Update()
    {
        if (!holding && Input.GetKeyDown(KeyCode.E))
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
        pickup.OnPickup();
        holding = true;
        yield return null;
        while (!Input.GetKeyDown(KeyCode.E))
        {
            pickupTransform.position = GetBoxCenter();
            yield return null;
        }
        pickup.OnDrop();
        yield return null;
        holding = false;
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
}

public interface IPickup
{
    void OnPickup();
    void OnDrop();
}