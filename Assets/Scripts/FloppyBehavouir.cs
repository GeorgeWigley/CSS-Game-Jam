using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyBehavouir : MonoBehaviour, IPickup
{
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

    public void Disappear() {
        Destroy(gameObject);
    }
}
