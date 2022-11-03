using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    public GameObject weight;
    public GameObject platform;
    public GameObject player;
    public Vector3 startPosition;
    public Vector3 weightPosition;
    public Vector3 platformPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reset");
            weight.transform.position = weightPosition;
            var obj = GameObject.FindWithTag("Disable");
            obj.GetComponent<MeshRenderer>().enabled = true;
            obj.GetComponent<Collider>().enabled = true;           
            //restart the level. 
            player.transform.position = startPosition;
            //destroy and instantiate weight, platform
            //var name = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(name);
        }
    }
}
