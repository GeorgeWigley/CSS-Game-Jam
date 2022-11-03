using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Kino;
public class FinalLevel : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float effectTimer;
    private float currTime;
    public AnalogGlitch glitch;
    public PostProcessVolume ppProfile;

    void Start(){
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > effectTimer) {
            ppProfile.weight = Mathf.Lerp(0, 1, (currTime + effectTimer) / (effectTimer + 10) );
            glitch.colorDrift = Mathf.Lerp(0, 0.25f, (currTime + effectTimer) / (effectTimer + 10) );
            glitch.scanLineJitter = Mathf.Lerp(0, 0.3f, (currTime + effectTimer) / (effectTimer + 10) );
            glitch.verticalJump = Mathf.Lerp(0, 0.1f, (currTime + effectTimer) / (effectTimer + 10) );
            glitch.horizontalShake = Mathf.Lerp(0, 0.1f, (currTime + effectTimer) / (effectTimer + 10) );
        }
        if (currTime > timer) {
            var manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().LoadNextLevel();
        }
    }
}
