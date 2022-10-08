using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Boss")]
    [SerializeField] float health = 3000;
    [SerializeField] Slider bossHealthBar;
    
    [Header("Boss Rising")]
    [SerializeField] Transform startingPositon;
    [SerializeField] float riseSpeed = 1f;
    [SerializeField] bool hasRisen = false;
    [SerializeField] float risingShakeMagnitude = 1f;

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

    void OnTriggerEnter(Collider other) 
    {
        
    }



}
