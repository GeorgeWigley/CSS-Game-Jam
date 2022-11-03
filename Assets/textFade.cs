using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class textFade : MonoBehaviour
{
    private float time;
    public float scale;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float opacity = (float)((Math.Sin(time * scale) + 1) / 2);
        text.color = new Color(1.0f, 1.0f, 1.0f, opacity);
    }
}
