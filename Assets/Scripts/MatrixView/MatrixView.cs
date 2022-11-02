using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixView : MonoBehaviour
{
    [SerializeField] private MatrixToggle[] toggles;

    private bool inMatrixView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inMatrixView)
            {
                ExitMatrixView();
            }
            else 
            {
                EnterMatrixView();
            }
            inMatrixView = !inMatrixView;
        }
    }

    private void EnterMatrixView()
    {
        foreach (MatrixToggle toggle in toggles)
        {
            toggle.EnterMatrixView();
        }
    }
    
    private void ExitMatrixView()
    {
        foreach (MatrixToggle toggle in toggles)
        {
            toggle.ExitMatrixView();
        }
    }
}
