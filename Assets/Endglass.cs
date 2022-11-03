using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endglass : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        var manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().LoadNextLevel();
    }
}
