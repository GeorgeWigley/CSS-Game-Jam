using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    public Texture[] textures;

    public int timesSmashed;

    public bool updateTexture;

// Start is called before the first frame update
void Start()
{
    timesSmashed = 0;
    updateTexture = false;
}

// Update is called once per frame
void Update()
{
    if (updateTexture) {
        updateTexture = false;
        GetComponent<Renderer>().material.mainTexture = textures[timesSmashed];
    }
}

public void smash() {
    timesSmashed += 1;
}
}
