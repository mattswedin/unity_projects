using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeScreen : MonoBehaviour
{
    [SerializeField] float amountOfShake = 20f;
    [SerializeField] float shakeMagnitude = 0.5f;
   
    public IEnumerator ScreenShake()
    {
        var cam = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cam.m_AmplitudeGain = shakeMagnitude;

        yield return new WaitForSecondsRealtime(amountOfShake);

        cam.m_AmplitudeGain = 0;
    }
}
