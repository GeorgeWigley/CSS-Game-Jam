using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask layerMask;
    private Transform transformLocal;
    [SerializeField] private int answerCode;
    private int currentCode;
    private bool correct;
    
    [SerializeField] GameObject wall;
    private BoxCollider wallCollider;
    [SerializeField] private Text text;
    void Start()
    {
        transformLocal = transform;
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
                    currentCode += value;
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
        {
            if (wallCollider.center.x == 0)
            {
                wallCollider.center += new Vector3(1.5f, 0, 0);
            }
            else
            {
                wallCollider.center += new Vector3(-1.5f, 0, 0);
            }
        }
    }
}
