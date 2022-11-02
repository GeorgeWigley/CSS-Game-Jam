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
        if (rb != null) {
            rb.isKinematic = true;
        }
    }

    public void OnDrop()
    {
        if (rb != null) {
            rb.isKinematic = false;
        }
    }

    public void Disappear() {
        Destroy(gameObject);
    }
}
