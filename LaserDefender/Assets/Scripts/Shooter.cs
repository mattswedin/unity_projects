using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Vector3 positionOffset = new Vector3(0f, 2f, 0f);
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = .2f;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float minimumFiringRate = .1f;
   
    public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    Player player;

    void Awake() 
    {
        player = FindObjectOfType<Player>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update()
    {
        Fire();
    }

    void Fire() 
    {
        if(player.getPoweredUp())
        {
            if (firingCoroutine == null)
            {
                firingCoroutine = StartCoroutine(FireContinuously());
            }
            else if (firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
                firingCoroutine = null;
            }
        }
        else
        {
            if (isFiring)
            {
                GameObject instance = Instantiate(projectilePrefab, transform.position + positionOffset, Quaternion.identity);

                Destroy(instance, projectileLifetime);
                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    audioPlayer.PlayShootingClipPlayer();
                    rb.velocity = transform.up * projectileSpeed;
                }
                isFiring = false;
            }
        }
    }

    IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position + positionOffset, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            SpriteRenderer sr = instance.GetComponentInChildren<SpriteRenderer>();
            if (rb != null)
            {
                sr.color = Random.ColorHSV(0f, 1f);
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVarience, baseFiringRate + firingRateVarience);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
