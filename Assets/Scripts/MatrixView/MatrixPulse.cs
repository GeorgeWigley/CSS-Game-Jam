using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

[ExecuteInEditMode]
public class MatrixPulse : MatrixToggle
{
    [SerializeField] private AnalogGlitch analogGlitch;
    [SerializeField] private Material pulse;

    private float t = 0;

    private void Start()
    {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        pulse.SetFloat("_Amount", 0);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, pulse);
    }

    private IEnumerator Lerp(float to)
    {
        while (Mathf.Abs(to - t) > float.Epsilon)
        {
            t = Mathf.MoveTowards(t, to, Time.deltaTime * 2);
            float td = Mathf.Abs(to - t);
            analogGlitch.scanLineJitter = td;
            analogGlitch.colorDrift = td;
            pulse.SetFloat("_Amount", t);
            yield return null;
        }
    }
    public override void EnterMatrixView()
    {
        StopAllCoroutines();
        StartCoroutine(Lerp(1));
    }

    public override void ExitMatrixView()
    {
        StopAllCoroutines();
        StartCoroutine(Lerp(0));
    }
}
