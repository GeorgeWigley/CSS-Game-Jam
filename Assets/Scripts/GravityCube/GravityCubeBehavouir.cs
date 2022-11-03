using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityCubeBehavouir : MatrixToggle
{
    public int counterMass;
    private bool inMatrix;
    public bool liftUp;
    public TMP_Text massText;

    void Start()
    {
        updateLabel();
        liftUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (liftUp) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5 * gameObject.GetComponent<Rigidbody>().mass);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloppyDisk")){
            counterMass++;
            if (counterMass > 127) {
                counterMass = -128;
            }
            updateLabel();
            collision.gameObject.GetComponent<FloppyBehavouir>().Disappear();
        }
    }

    public override void EnterMatrixView()
    {
        inMatrix = true;
        updateLabel();
    }

    public override void ExitMatrixView()
    {
        inMatrix = false;
        if (counterMass < 0) {
            liftUp = true;
        }
        updateLabel();
    }

    private string intToBin(int x) {
        var res = "";
        if (x < 0) {
            res += "1";
            x += 128;
        } else {
            res += "0";
        }
        foreach (int unit in new int[] {64, 32, 16, 8, 4, 2, 1}) {
            if (x >= unit) {
                res += "1";
                x -= unit;
            } else {
                res += "0";
            }
        }
        return res;
    }

    private void updateLabel() {
        if (inMatrix) {
            massText.text = "(bin)\n"+ intToBin(counterMass)+ "\nkg";
        } else {
            massText.text = "(int)\n"+counterMass.ToString() + "\nkg";
        }
    }
}
