using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixView : MonoBehaviour
{
    [SerializeField] private MatrixToggle[] toggles;
    [SerializeField] private bool manualActivationAllowed;
    [SerializeField] private AudioSource effectSound;
    private bool inMatrixView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && manualActivationAllowed)
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

    public void EnterMatrixView()
    {
        effectSound.Play();
        foreach (MatrixToggle toggle in toggles)
        {
            if (toggle != null)
            {
                toggle.EnterMatrixView();
            }
        }
    }
    
    public void ExitMatrixView()
    {
        effectSound.Play();
        foreach (MatrixToggle toggle in toggles)
        {
            if (toggle != null)
            {
                toggle.ExitMatrixView();
            }
        }
    }
}
