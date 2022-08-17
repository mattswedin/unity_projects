using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] AudioSource rocketSFX;
    bool invincibilityFrames = false;
    Rigidbody rb;
    PlayerStats playerStats;

    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    //Movement

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * playerStats.GetThrustForce() * Time.deltaTime);
            if (!rocketSFX.isPlaying)
            {
                rocketSFX.Play();
            }
        }
        else
        {
            rocketSFX.Pause();
        }

    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.left);
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
            invincibilityFrames = true;
            playerStats.LoseLife();
            yield return new WaitForSeconds(playerStats.GetInvincibilityTime());
            invincibilityFrames = false;
        }
    }
}
