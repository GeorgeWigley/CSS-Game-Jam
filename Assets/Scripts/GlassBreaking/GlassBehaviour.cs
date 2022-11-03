using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    public Material[] textures;

    public int timesSmashed;

    public bool smashedThisReset;
    public GameObject smashedGlass;

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
            GetComponent<Renderer>().material = textures[timesSmashed - 1];
        }
    }

    void OnCollisionEnter (Collision targetObj) {
        Debug.Log("COLLISION");
        if (!smashedThisReset && targetObj.gameObject.tag == "Smasher")
        {
            Debug.Log("Actual collision");
            timesSmashed += 1;
            updateTexture = true;
            smashedThisReset = true;
            if (timesSmashed == 5) {
                // replace object
                smashedGlass.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        
    }
}
