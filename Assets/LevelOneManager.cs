using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    public PostProcessVolume vfxStack;
    float timeElapsed;
    float lerpDuration = 3;
    float startValue = 0;
    float endValue = 1;
    float valueToLerp;
    void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
    }

    public void CompleteLevel()
    {

    }

}
