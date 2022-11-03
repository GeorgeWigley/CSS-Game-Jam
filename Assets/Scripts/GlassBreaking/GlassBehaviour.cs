using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    public Texture[] textures;

    public int timesSmashed;

    public bool smashedThisReset;

    public bool updateTexture;

// Start is called before the first frame update
void Start()
{
    timesSmashed = 0;
    updateTexture = false;
    smashedThisReset = false;
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
    if (!smashedThisReset) {
        timesSmashed += 1;
        updateTexture = true;
        smashedThisReset = true;
        if (timesSmashed == 5) {
            // replace object
        }
    }
}
}
