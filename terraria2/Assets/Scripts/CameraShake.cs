using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    float x;
    float t;
    bool runPerl,canWork;
    public CinemachineVirtualCamera cvcam;
    public void CameraShaker(float speedFadeIn,float maxAmplitude,float minAmplitude)
    {
        runPerl = true;
        canWork = true;
        StartCoroutine(Shaker(speedFadeIn,maxAmplitude,minAmplitude));
        //cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }
    IEnumerator Shaker(float speedFadeIn,float maxAmplitude,float minAmplitude)
    {
        CinemachineBasicMultiChannelPerlin cvcamNoise = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        while (runPerl)
        {
            x = Mathf.Lerp(minAmplitude, maxAmplitude, t);
            t += speedFadeIn * Time.deltaTime;
            cvcamNoise.m_AmplitudeGain = x;
            if (x==maxAmplitude)
            {
                runPerl = false;
                t = 0;
            }
            yield return null;
        }
        while (!runPerl && canWork)
        {
            x = Mathf.Lerp(maxAmplitude, minAmplitude, t);
            t += speedFadeIn * Time.deltaTime;

            cvcamNoise.m_AmplitudeGain = x;
            if (x == minAmplitude)
            {
                canWork = false;
                cvcamNoise.m_AmplitudeGain = 0f;
                t = 0;
                x = 0;
            }
            yield return null;
            
        }
    }
}
