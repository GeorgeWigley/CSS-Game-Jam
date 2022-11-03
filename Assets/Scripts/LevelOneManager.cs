using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Kino;

public class LevelOneManager : MonoBehaviour
{
    public AudioSource outroSound;
    public GravityCubeBehavouir cube;
    public AnalogGlitch glitch;
    public PostProcessVolume ppProfile;
    float timeElapsed;
    float lerpDuration = 5;

    bool startedPlaying = false;

    void Update()
    {
        if (cube.liftUp)
        {
            if (!startedPlaying) {
                startedPlaying = true;
                outroSound.Play();
            }
            if (timeElapsed < lerpDuration)
            {
                ppProfile.weight = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
                glitch.colorDrift = Mathf.Lerp(0, 0.25f, timeElapsed / lerpDuration);
                glitch.scanLineJitter = Mathf.Lerp(0, 0.3f, timeElapsed / lerpDuration);
                glitch.verticalJump = Mathf.Lerp(0, 0.1f, timeElapsed / lerpDuration);
                glitch.horizontalShake = Mathf.Lerp(0, 0.1f, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;

            }
            else{
                var manager = GameObject.Find("GameManager");
                manager.GetComponent<GameManager>().LoadNextLevel();
            }
        }


    }


}
