using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGameObjectToggle : MatrixToggle
{
    public override void EnterMatrixView()
    {
        gameObject.SetActive(true);
    }

    public override void ExitMatrixView()
    {
        gameObject.SetActive(false);
    }
}
