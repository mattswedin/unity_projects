using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeScreen : MonoBehaviour
{
    [SerializeField] float amountOfShake = 20f;
    [SerializeField] float shakeMagnitude = 0.5f;
    [SerializeField] bool screenShakeBool;
    CinemachineBasicMultiChannelPerlin cam;

    void Awake() 
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
   
    public IEnumerator ScreenShake()
    {
        cam.m_AmplitudeGain = shakeMagnitude;

        yield return new WaitForSecondsRealtime(amountOfShake);

        cam.m_AmplitudeGain = 0;
    }

    public void ScreenShakeBool(float magnitude)
    {
        cam.m_AmplitudeGain = magnitude;
    }
}
