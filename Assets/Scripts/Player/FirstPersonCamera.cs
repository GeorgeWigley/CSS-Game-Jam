using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float minAngle = -90;
    [SerializeField] private float maxAngle = 90;
    [SerializeField] private float sensitivity = 1;

    private float xAngle;
    private float yAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() 
    {
        xAngle -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xAngle = Mathf.Clamp(xAngle, minAngle, maxAngle);
        yAngle += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(xAngle, yAngle, 0);
    }
}
