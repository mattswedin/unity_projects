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

    [Header("Boss Hands")]
    [SerializeField] GameObject BossHandLeft;
    [SerializeField] float leftSpeed;
    [SerializeField] GameObject BossHandRight;
    [SerializeField] float rightSpeed;

    [Header("Boss Hands Rising")]
    [SerializeField] Transform leftHandsUpPos;
    [SerializeField] Transform leftHandsDownPos;
    [SerializeField] Transform rightHandsUpPos;
    [SerializeField] Transform rightHandsDownPos;

    bool handsUp;

    ShakeScreen shakeScreen;

    void Awake() 
    {
        shakeScreen = FindObjectOfType<ShakeScreen>();
    }
   
    void Update() 
    {
        if (!hasRisen)
        {
            HandsRise();

            if (handsUp)
            {
                Rise();
            }  
        }
        else
        {
            RandomAttacks();
        }
    }

    void RandomAttacks() 
    {

    }

    void ClapAttack()
    {

    }

    void HandsRise()
    {
        BossHandRight.transform.position = Vector3.MoveTowards(BossHandRight.transform.position, rightHandsUpPos.position, rightSpeed * Time.deltaTime);

        if (BossHandRight.transform.position == rightHandsUpPos.position)
        {

            BossHandRight.transform.rotation = Quaternion.RotateTowards(BossHandRight.transform.rotation, rightHandsDownPos.rotation, rightSpeed * Time.deltaTime);

            // BossHandRight.transform.position = Vector3.MoveTowards(BossHandRight.transform.position, rightHandsDownPos.position, rightSpeed * Time.deltaTime);

            if (BossHandRight.transform.position == rightHandsDownPos.position && BossHandRight.transform.rotation == rightHandsDownPos.rotation)
            {
                handsUp = true;
            }
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
