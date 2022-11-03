using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherBehaviour : MatrixToggle
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterMatrixView() {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public override void ExitMatrixView() {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
