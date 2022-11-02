using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMatrixController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject screen;
    private Vector3 cameraDefault;
    private Vector3 playerDefault;

    // Start is called before the first frame update
    void Start()
    {
        cameraDefault = transform.position;
        playerDefault = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get play pos relative to start
        Vector3 offset = (mainCamera.transform.position - playerDefault) + (mainCamera.transform.position - screen.transform.position);
        transform.position = cameraDefault + offset;
        transform.rotation = mainCamera.transform.rotation;

    }
}
