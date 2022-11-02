using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPathMatrixBehaviour : MatrixToggle
{
    //private bool inMatrix;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void EnterMatrixView() {
        gameObject.SetActive(true);
    }

    public override void ExitMatrixView() {
        gameObject.SetActive(false);
    }
}
