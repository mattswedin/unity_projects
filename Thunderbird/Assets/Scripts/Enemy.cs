using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float health = 100;
    [SerializeField] Material[] hitColor;
    [SerializeField] GameObject normalVersion;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] float attackPower = 0;
    int hitColorIndex = 0;
    List<Material> og = new List<Material>();
    MeshRenderer[] meshRenderers;
    bool ogMaterialsObtained;
    bool died;

    [Header("Enemy Type")]
    [Header("Flying Between Points")]
    [SerializeField] bool isFlyingBetweenPoints;
    [SerializeField] Transform[] points;
    [SerializeField] int flyingSpeedBetweenPoints;
    int j = 0;
    [Header("Flightless Running")]
    [SerializeField] bool isFlightlessRunning;
    [Header("Rotating Between Points")]
    [SerializeField] bool isRotatingBetweenPoints;
    [SerializeField] int rotationSpeed;
    [Header("Boss")]
    [SerializeField] PlayableDirector pd;
    [SerializeField] bool isBoss;
    [SerializeField] bool bossDefeated = false;
    [SerializeField] GameObject hitZone;
    [SerializeField] GameObject bossProjectile;
    [SerializeField] Transform bossProjectileLocation;
    [SerializeField] Vector3 startingPos;
    [SerializeField] float bossStunTime = 1f;
    [SerializeField] double bossSlowMo = .0050;
    [SerializeField] float bossFallTime = 5f;
    [SerializeField] float bossFallSpeed = 3f;
    [SerializeField] Vector3 bossEndPos;
    int bossPhases = 3;
    Animator animator;
    GameStats gameStats;
    BossController bossController;
    
    

    void Awake()
    {
        gameStats = FindObjectOfType<GameStats>();
        if (isBoss) 
        {
            pd =  GetComponent<PlayableDirector>();
            animator = GetComponentInChildren<Animator>();
            bossController = FindObjectOfType<BossController>();
            meshRenderers = hitZone.GetComponents<MeshRenderer>();
        }
        else
        {
            meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        }
        
    }

    void Update() 
    {
       if (ogMaterialsObtained) BringOGColorsBack();
       if (isFlyingBetweenPoints) PositionMovement();
       if (isRotatingBetweenPoints) RotationMovement();
       if (bossDefeated) BossExit();
    }

    void PositionMovement()
    {
        if (points.Length != 0 && j < points.Length)
        {
            Vector3 currentPoint = points[j].position;
            transform.position = Vector3.MoveTowards(transform.position, currentPoint, flyingSpeedBetweenPoints * Time.deltaTime);
            
            if (transform.position == currentPoint)
            {
                if (j != points.Length - 1)
                {
                    j++;
                }
                else
                {
                    j = 0;
                }
            }
        }
    }
    void RotationMovement()
    {
        if (points.Length != 0 && j < points.Length)
        {
            Quaternion currentRotation = points[j].rotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentRotation, rotationSpeed * Time.deltaTime);

            if (transform.rotation == currentRotation)
            {
                
                if (j != points.Length - 1)
                {
                    j++;
                }
                else
                {
                    j = 0;
                }
            }
        }
    }

    void OnParticleCollision(GameObject other) 
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            MeshRenderer mesh = meshRenderers[i];
            og.Add(mesh.material);
            mesh.material = hitColor[hitColorIndex];
        }
        if (!ogMaterialsObtained) ogMaterialsObtained = true;
        health -= gameStats.GetLaserPower();
        if (hitColorIndex == 0)
        {
            hitColorIndex = 1;
        }
        else
        {
            hitColorIndex = 0;
        }
        if (health < 1) Death(); 
    }

    void Death()
    {
        if (!died)
        {
            if (deathExplosion != null && isBoss) 
            {
                Instantiate(deathExplosion, hitZone.transform.position, hitZone.transform.rotation);
                
                
            }
            else if (deathExplosion != null)
            {
                Instantiate(deathExplosion, transform.position, transform.rotation);
            }
                

            if (normalVersion != null)
            {
                GameObject normie = Instantiate(normalVersion, transform.position, transform.rotation);
                normie.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
            } 
            died = true;
            if (isBoss) StartCoroutine(BossPhaseIsOver());
            if (!isBoss) gameStats.SetBirdsCured();
            
        }
        
        if (isBoss) 
        {
            Destroy(hitZone);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void BringOGColorsBack()
    {
        if (!died) 
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material = og[i];
            }
        }

    }

    public float GetAttackPower()
    {
        return attackPower;
    }

    IEnumerator BossPhaseIsOver()
    {
        pd.playableGraph.GetRootPlayable(0).SetSpeed<Playable>(bossSlowMo);
        yield return new WaitForSeconds(bossStunTime);
        pd.playableGraph.Stop();
        bossEndPos.x = transform.position.x;
        bossEndPos.y = transform.position.y - 200;
        bossEndPos.z = transform.position.z;
        bossDefeated = true;
    }

    void BossExit() 
    {
        transform.position = Vector3.MoveTowards(transform.position, bossEndPos, bossFallSpeed * Time.deltaTime);

        if (transform.position == bossEndPos)
        {
            StartCoroutine(bossController.EndBossPhaseOne());
        }
    }

    public void BossShoot()
    {
        Instantiate(bossProjectile, bossProjectileLocation.position, Quaternion.identity);
    }


}
