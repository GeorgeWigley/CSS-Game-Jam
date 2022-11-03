using System;
using System.Collections;
using System.Collections.Generic;
using Kino;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class LevelThreeManager : MonoBehaviour
{
    [SerializeField] private float onLength;
    [SerializeField] private float offLength;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private AnalogGlitch glitch;
    [SerializeField] private MatrixView matrixView;
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private string[] errorMessages;
    private bool isOn = true;
    private float currentOn;
    private float currentOff;

    void Start()
    {
        currentOn = onLength;
        currentOff = offLength;
        errorText.text = "";
        matrixView.EnterMatrixView();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            currentOn -= Time.deltaTime;
            if (currentOn < 0)
            {
                isOn = false;
                currentOn = onLength;
                TurnOff();
            }
        }
        else
        {
            currentOff -= Time.deltaTime;
            if (currentOff < 0)
            {
                isOn = true;
                currentOff = offLength;
                TurnOn();
            }
        }
    }

    private void TurnOff()
    {
        errorText.text = errorMessages[Random.Range(0,2)];
        matrixView.ExitMatrixView();
        StartCoroutine(nameof(HideText));
        StartCoroutine(nameof(GlitchTemp));
    }

    private void TurnOn()
    {
        errorText.text = "Reloaded Brainchip, compilation successful (1.14s)";
        matrixView.EnterMatrixView();
        StartCoroutine(nameof(HideText));
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3);
        errorText.text = "";

    }
    
    IEnumerator GlitchTemp()
    {
        for (int i = 0; i < 50; i++)
        {
            glitch.colorDrift += 0.01f;
            glitch.scanLineJitter += 0.01f;
            glitch.verticalJump += 0.01f;
            glitch.horizontalShake += 0.01f;
            yield return null;
        }
        for (int i = 0; i < 50; i++)
        {
            glitch.colorDrift -= 0.01f;
            glitch.scanLineJitter -= 0.01f;
            glitch.verticalJump -= 0.01f;
            glitch.horizontalShake -= 0.01f;
            yield return null;
        }
    }

    // collider attached to manager to reset players spawn
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint;
    }
}
