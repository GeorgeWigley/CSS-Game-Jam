using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPathMatrixBehaviour : MatrixToggle
{
    //private bool inMatrix;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    
    public override void EnterMatrixView() {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public override void ExitMatrixView() {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
