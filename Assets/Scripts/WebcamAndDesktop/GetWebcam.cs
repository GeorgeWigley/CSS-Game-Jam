using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWebcam : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        //Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired

        WebCamTexture tex = new WebCamTexture(devices[0].name);
        //rend.material.mainTexture = tex;
        mat.mainTexture = tex;
        tex.Play();
    }
}
