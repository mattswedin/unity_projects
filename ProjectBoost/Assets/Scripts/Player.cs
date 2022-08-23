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
    bool cantMove = false;
    bool invincibilityFrames = false;
    Rigidbody rb;
    PlayerStats playerStats;
    AudioPlayer audioPlayer;
    CollisionHandler collisionHandler;

    void Awake() 
    {
        collisionHandler = FindObjectOfType<CollisionHandler>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() 
    {
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

    public void SetCantMove(bool state) 
    {
        cantMove = state;
    }

    IEnumerator AppearAtStart()
    {
        
        foreach (Transform child in transform.GetChild(0)) 
        {
            child.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(.1f);
        audioPlayer.PlayAppearVanish();
        appearEffect.Play();

        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(true);
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
            if (!jetArmRight.isPlaying)
            {
                jetArmRight.Play();
            }
            else
            {
                jetArmLeft.Play();
            }
            ApplyRotation(Vector3.right);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.A))
        {
            if (!jetArmLeft.isPlaying)
            {
                jetArmLeft.Play();
            }
            else
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
            loseLifeEffect.Play();
            invincibilityFrames = true;
            playerStats.LoseLife();
            collisionHandler.PlayExplosion();
            yield return new WaitForSeconds(playerStats.GetInvincibilityTime());
            invincibilityFrames = false;
        }
    }
}
