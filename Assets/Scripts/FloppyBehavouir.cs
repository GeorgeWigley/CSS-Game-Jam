using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyBehavouir : MatrixToggle, IPickup
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

    public override void EnterMatrixView()
    {
        gameObject.SetActive(true);
    }

    public override void ExitMatrixView()
    {
        gameObject.SetActive(false);
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
