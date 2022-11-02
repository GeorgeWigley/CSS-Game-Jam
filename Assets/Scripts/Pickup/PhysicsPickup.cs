using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour, IPickup
{
    [SerializeField] private Collider[] colliders;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnPickup()
    {
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }
        rb.isKinematic = true;
    }

    public void OnDrop()
    {
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
        rb.isKinematic = false;
    }
}
