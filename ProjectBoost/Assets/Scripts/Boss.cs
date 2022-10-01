using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform startingPositon;
    [SerializeField] float riseSpeed = 1f;
    [SerializeField] bool hasRisen = false;
    [SerializeField] float risingShakeMagnitude = 1f;


    CinemachineBasicMultiChannelPerlin cam;
    ShakeScreen shakeScreen;

    void Awake() 
    {
        shakeScreen = FindObjectOfType<ShakeScreen>();
    }
   
    void Update() 
    {
        if (!hasRisen)
        {
            Rise();
        }
    }
        

    void Rise() 
    {
        shakeScreen.ScreenShakeBool(risingShakeMagnitude);
        transform.position = Vector3.MoveTowards(transform.position,
                                                    startingPositon.position,
                                                    riseSpeed * Time.deltaTime);
        if (transform.position == startingPositon.position)
        {
            hasRisen = true;
            shakeScreen.ScreenShakeBool(0);
        }  
    }



}
