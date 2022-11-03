using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHitDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity);

        if (isHit)
        {

            var script = hitInfo.collider.gameObject.GetComponent<ButtonBehaviour>();
            if ( script != null)
            {
                script.OnClick();
            }
            else  {
                Debug.Log("BUTTON MISSED")
            }
        }
    }
}
}
