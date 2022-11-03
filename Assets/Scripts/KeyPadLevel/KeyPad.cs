using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MatrixToggle
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask layerMask;
    private Transform transformLocal;
    [SerializeField] private ulong answerCode;
    private ulong currentCode;
    private bool correct;
    
    [SerializeField] GameObject wall;
    private BoxCollider wallCollider;
    [SerializeField] private Text text;
    [SerializeField] private GameObject obstruction;
    void Start()
    {
        transformLocal = Camera.main.transform;
        currentCode = 0;
        correct = false;
        updateText();

        wallCollider = wall.GetComponent<BoxCollider>();
    }

    void updateText()
    {
        text.text = $"Code : {currentCode}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (correct)
                return;
            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(transformLocal.position, transformLocal.forward, out hitInfo, Mathf.Infinity, layerMask);
            
            if (isHit)
            {

                var script = hitInfo.collider.gameObject.GetComponent<KeyValue>();
                int value = script.Value;
                
                if (value >= 0)
                {
                    currentCode *= 10;
                    currentCode += (ulong) value;
                    updateText();
                }
                else if (value == -1)
                {
                    currentCode = 0;
                    updateText();
                }
                else
                {
                    if (currentCode == answerCode)
                    {
                        correct = true;
                        text.text = "Correct!";
                        obstruction.SetActive(false);
                    }
                    else
                    {
                        text.text = "Incorrect!";
                        currentCode = 0;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
            wallCollider.enabled = !wallCollider.enabled;
    }

    public override void EnterMatrixView()
    {
        Debug.Log(wallCollider.center);
    }

    public override void ExitMatrixView()
    {
        wallCollider.center += new Vector3(1.5f, 0, 0);
    }
}
