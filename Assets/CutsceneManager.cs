using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(NextScene));
    }

    IEnumerator NextScene() {
        yield return new WaitForSeconds(34);
        var manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().LoadNextLevel();
    }
}
