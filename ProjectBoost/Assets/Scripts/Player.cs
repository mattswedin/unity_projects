using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] AudioSource rocketSFX;
    [SerializeField] ParticleSystem appearEffect;
    [SerializeField] ParticleSystem loseLifeEffect;
    [SerializeField] ParticleSystem jetLegLeft;
    [SerializeField] ParticleSystem jetLegRight;
    [SerializeField] ParticleSystem jetArmLeft;
    [SerializeField] ParticleSystem jetArmRight;
    [SerializeField] Collider headCollider;
    [SerializeField] bool cantMove = false;

    [Header("Special Weapon")]
    [SerializeField] bool isPoweredUpRobot;

    bool invincibilityFrames = false;
    Rigidbody rb;
    PlayerStats playerStats;
    AudioPlayer audioPlayer;
    CollisionHandler collisionHandler;
    ShakeScreen shakeScreen;
    FadeInOut fadeInOut;

    void Awake() 
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody>();
        shakeScreen = FindObjectOfType<ShakeScreen>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start() 
    {   if (isPoweredUpRobot)
    {
        SetUpSpecialWeapon();
    }
        SetUpColliderIgnore();
        StartCoroutine(AppearAtStart());
    }


    void Update()
    {
        if (!cantMove)
        {
            ProcessRotation();
            ProcessThrust();         
        }
    }

    void SetUpColliderIgnore()
    {
       GameObject allFrogs = GameObject.Find("Frogs");
       
       if (allFrogs != null)
       {
            int childCount = allFrogs.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                if (allFrogs.transform.GetChild(i).transform.childCount > 0)
                {
                    GameObject childFrog = allFrogs.transform.GetChild(i).gameObject;
                    int childsChildCount = childFrog.transform.childCount;
                    GameObject childCollider = childFrog.transform.GetChild(childsChildCount - 1).gameObject;
                    Collider childFrogCollider = childCollider.GetComponent<Collider>();
                    Physics.IgnoreCollision(headCollider, childFrogCollider, true);
                }
            }
       }
    }

    public void SetCantMove(bool state) 
    {
        cantMove = state;
    }

    IEnumerator AppearAtStart()
    {
        rb.useGravity = false;
        cantMove = true;
        foreach (Transform child in transform.GetChild(0)) 
        {
            child.gameObject.SetActive(false);
        }
        fadeInOut.FadeOutBlack();
        yield return new WaitForSeconds(1.3f);
        audioPlayer.PlayAppearVanish();
        appearEffect.Play();
        cantMove = false;
        rb.useGravity = true;

        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(true);
        }
    }

    void SetUpSpecialWeapon()
    {
        int total = playerStats.GetFrogTotalCount();
        GameObject specialWeapon = GameObject.Find("SpecialWeapon");

        if (total == 0)
        {
            //game over
        }
        else if (total <= 6)
        {
            //tiny spike
            specialWeapon.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (total > 6 && total <= 12)
        {
            //regs spike
            specialWeapon.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (total > 12 && total <= 18)
        {
            //plug
            specialWeapon.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (total > 18 && total <= 24)
        {
            //frog spike
            specialWeapon.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (total > 24 && total <= 30)
        {
            //frog plug
            specialWeapon.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (total > 30 && total < 36)
        {
            //frog gun
            specialWeapon.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (total == 36)
        {
            //frog sword
            specialWeapon.transform.GetChild(6).gameObject.SetActive(true);
        }
    }

   public IEnumerator DissapearAtFinish()
    {
        appearEffect.Play();
        audioPlayer.PlayAppearVanish();
        yield return new WaitForSeconds(.1f);
        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(false);
        }
    }
    

    //Movement

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * playerStats.GetThrustForce() * Time.deltaTime);
            if (!rocketSFX.isPlaying)
            {
                jetLegLeft.Play();
                jetLegRight.Play();
                rocketSFX.Play();
            }
        }
        else
        {
            jetLegLeft.Stop();
            jetLegRight.Stop();
            rocketSFX.Pause();
        }

    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            if (!jetArmLeft.isPlaying)
            {
                jetArmLeft.Play();
            }
        
            ApplyRotation(Vector3.right);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.A))
        {
            if (!jetArmRight.isPlaying)
            {
                jetArmRight.Play();
            }
            
            ApplyRotation(Vector3.left);
        }
        else
        {
            if (jetArmLeft.isPlaying)
            {
                jetArmLeft.Stop();
            }
            if (jetArmRight.isPlaying)
            {
                jetArmRight.Stop();
            }
        }
    }

    void ApplyRotation(Vector3 direction) 
    {
        transform.Rotate(direction * playerStats.GetRotateThrustForce() * Time.deltaTime);
    }

    //Health

    public IEnumerator LoseLife() 
    {  
        if (!invincibilityFrames)
        {
            StartCoroutine(shakeScreen.ScreenShake());
            loseLifeEffect.Play();
            invincibilityFrames = true;
            playerStats.LoseLife();
            collisionHandler.PlayExplosion();
            yield return new WaitForSeconds(playerStats.GetInvincibilityTime());
            invincibilityFrames = false;
        }
    }
}
