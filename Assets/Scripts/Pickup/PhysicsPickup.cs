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
        rb.isKinematic = true;
    }

    public void OnDrop()
    {
        rb.isKinematic = false;
    }
}
