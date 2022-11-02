using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityCubeBehavouir : MatrixToggle
{
    public int counterMass;

    // Update is called once per frame
    void Update()
    {
        if (counterMass < 0) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 800);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloppyDisk")){
            counterMass++;
            if (counterMass > 127) {
                counterMass = -128;
            }
            collision.gameObject.GetComponent<FloppyBehavouir>().Disappear();
        }
    }

    public override void EnterMatrixView()
    {
        Debug.Log(Convert.ToString(counterMass, 2));
    }

    public override void ExitMatrixView()
    {
        Debug.Log("exiting the matrix");
    }
}
