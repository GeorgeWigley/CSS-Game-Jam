using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCubeMatrixBehavouir : MatrixToggle
{
    public override void EnterMatrixView()
    {
        Debug.Log("entering the matrix");
    }

    public override void ExitMatrixView()
    {
        Debug.Log("exiting the matrix");
    }
}
