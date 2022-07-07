using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // [SerializeField] ParticleSystem scratchspolsion;
    [SerializeField] int health = 50;
    [Header("Player Only")]
    [SerializeField] bool isPlayer = false;
    Rigidbody2D playerRB;
    [SerializeField] float suckPower = 2f;
    [SerializeField] float suckTime = 20f;
    [SerializeField] float stunTime = 30f;
    [SerializeField] float stunMovement = .01f;
    Player playerScript;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isVacuum;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    
    void Awake() 
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() {

        if (isPlayer)
        {
            playerRB = GetComponent<Rigidbody2D>();
            playerScript = FindObjectOfType<Player>();
        }

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer)
        {
            if (other.tag == "lightningBolt" && isPlayer)
            {
                StartCoroutine(Stunned());
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
            else if (other.tag == "dustSuck" && isPlayer)
            {
                playerScript.stunned = false;
                StartCoroutine(Sucked());
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
            else if (isPlayer)
            {
                TakeDamage(damageDealer.GetDamage());
                ShakeCamera();
                
                damageDealer.Hit();
            }
            else
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }
       
    }

    IEnumerator Sucked()
    {
        for (int i = 0; i < 1; i++)
        {
            playerRB.velocity += new Vector2(0f, suckPower);
            yield return new WaitForSeconds(suckTime);
        }
        playerRB.velocity = Vector2.zero;
    }

    IEnumerator Stunned()
    {
        Vector3 ogPosition = transform.position;

        
        playerScript.stunned = true;
        for (int i = 0; i < stunTime; i++){
            if (transform.position.x > ogPosition.x){
                transform.position = ogPosition;
                transform.position += new Vector3(-stunMovement, 0f);
            }
            else
            {
                transform.position = ogPosition;
                transform.position += new Vector3(stunMovement, 0f);
            }
            Debug.Log(ogPosition);
            yield return new WaitForSeconds(.01f);
        }
        transform.position = ogPosition;
        playerScript.stunned = false;

    }

    void TakeDamage(int damageTaken) 
    {
        
        health -= damageTaken;
        
        if (health <= 0)
        {
            if (isVacuum) 
            {
                audioPlayer.StopAudio();
            }
            audioPlayer.PlayDamageClip();
            Destroy(gameObject);
        }
    }

    void ShakeCamera() 
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
