using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MatrixViewPostProcessing : MatrixToggle
{
    [SerializeField] private PostProcessVolume volume;

    public override void EnterMatrixView()
    {
        volume.weight = 1;
    }

    public override void ExitMatrixView()
    {
        volume.weight = 0;
    }
}
