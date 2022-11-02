using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatrixToggle : MonoBehaviour, IMatrixToggle
{
    public abstract void EnterMatrixView();
    public abstract void ExitMatrixView();
}

public interface IMatrixToggle
{
    void EnterMatrixView();
    void ExitMatrixView();
}

