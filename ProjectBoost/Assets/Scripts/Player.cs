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

    void Awake() 
    {
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
        appearEffect.Play();
        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(true);
        }
    }

   public IEnumerator DissapearAtFinish()
    {
        appearEffect.Play();
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
            if (jetArmRight.isEmitting)
            {
                jetArmRight.Stop();
            }
            jetArmLeft.Play();
            ApplyRotation(Vector3.right);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.A))
        {
            if (jetArmLeft.isEmitting)
            {
                jetArmLeft.Stop();
            }
            jetArmRight.Play();
            ApplyRotation(Vector3.left);
        }
        else
        {
            if (jetArmLeft.isEmitting)
            {
                jetArmLeft.Stop();
            }
            if (jetArmRight.isEmitting)
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
            yield return new WaitForSeconds(playerStats.GetInvincibilityTime());
            invincibilityFrames = false;
        }
    }
}
