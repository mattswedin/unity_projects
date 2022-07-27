using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<GameObject> finalBossProjectilePrefabs;
    [SerializeField] bool isFinalBoss;
    [SerializeField] Vector3 positionOffset = new Vector3(0f, 2f, 0f);
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = .2f;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float minimumFiringRate = .1f;
    [SerializeField] string enemyType = "vacuum";

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    public bool isFiring;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() 
    {
        if (enemyType == "vacuum") 
        {
            audioPlayer.PlayShootingClipEnemy(enemyType);
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously() 
    {
        while(isFiring) 
        {
            GameObject instance;

            if (isFinalBoss && finalBossProjectilePrefabs.Count > 0)
            {
                int random = Random.Range(0, finalBossProjectilePrefabs.Count);
                instance = Instantiate(finalBossProjectilePrefabs[random], transform.position + positionOffset, Quaternion.identity);
            }
            else
            {
                instance = Instantiate(projectilePrefab, transform.position + positionOffset, Quaternion.identity);
            }
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            
            if (rb != null) 
            {
                if (enemyType != "vacuum")
                {
                    audioPlayer.PlayShootingClipEnemy(enemyType);
                }               
                rb.velocity = -transform.up * projectileSpeed;
            }
            
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVarience, baseFiringRate + firingRateVarience);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }

    }
}
