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
    [SerializeField] bool isMiniBoss;
    [SerializeField] bool isHand;
    [SerializeField] int handsDefeated = 0;
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
    [SerializeField] bool canShoot = false;
    [SerializeField] int oddsOfShooting = 6;
    [SerializeField] float bossRotationSpeed = 3f;
    [SerializeField] bool isRoamingSpiralEyes;
    Quaternion endRotation;
    int bossPhases = 3;

    Animator animator;
    Animator animatorInstance;
    GameStats gameStats;
    BossController bossController;
    UIController uIController;
    Enemy mainEnemy;
    float incomingDamage;
    
    

    void Awake()
    {
        gameStats = FindObjectOfType<GameStats>();
        if (isBoss) 
        {
            pd =  GetComponent<PlayableDirector>();
            animator = GetComponentInChildren<Animator>();
            meshRenderers = hitZone.GetComponents<MeshRenderer>();
            uIController = FindObjectOfType<UIController>();
        }
        else if (isMiniBoss)
        {
            mainEnemy = transform.parent.parent.GetComponent<Enemy>();
            animatorInstance = transform.parent.parent.GetChild(0).GetComponent<Animator>();
            meshRenderers = hitZone.GetComponents<MeshRenderer>();
        }
        else
        {
            meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        }
        
    }

    void Start() 
    {
        if (isBoss || isHand) bossController = FindObjectOfType<BossController>();   
    }

    void Update() 
    {
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
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(gameObject.name);
        
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            MeshRenderer mesh = meshRenderers[i];
            if (!ogMaterialsObtained) og.Add(mesh.material);
            mesh.material = hitColor[hitColorIndex];
        }
        if (!ogMaterialsObtained) ogMaterialsObtained = true;

        incomingDamage = gameStats.GetLaserPower();
        if (isBoss) uIController.BossHealth(incomingDamage);
        if (isRoamingSpiralEyes) gameStats.SpiralEyesDamage(incomingDamage);
        health -= incomingDamage;
        

        if (hitColorIndex == 0)
        {
            hitColorIndex = 1;
        }
        else
        {
            hitColorIndex = 0;
        }

        if (health < 1) Death();
        //TEST
        if (ogMaterialsObtained) StartCoroutine(BringOGColorsBack());
    }

    // void OnParticleCollision(GameObject other) 
    // {
    //     for (int i = 0; i < meshRenderers.Length; i++)
    //     {
    //         MeshRenderer mesh = meshRenderers[i];
    //         if (!ogMaterialsObtained) og.Add(mesh.material);
    //         mesh.material = hitColor[hitColorIndex];
    //     }

    //     if (!ogMaterialsObtained) ogMaterialsObtained = true;

    //     if (isBoss) uIController.BossHealth(gameStats.GetLaserPower());

    //     health -= gameStats.GetLaserPower();

    //     if (hitColorIndex == 0)
    //     {
    //         hitColorIndex = 1;
    //     }
    //     else
    //     {
    //         hitColorIndex = 0;
    //     }

    //     if (health < 1) Death(); 
    // }

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

            if (isBoss) 
            {
                StartCoroutine(BossPhaseIsOver());
            }
            else if (isMiniBoss)
            {
                if (isHand) 
                {
                   animatorInstance.SetBool("handDestroyed", true);
                   mainEnemy.CanBossShoot(true);
                   bossController.HandDefeated();
                   Destroy(gameObject);
                }

            }
            else 
            {
                gameStats.SetBirdsCured();
            }
            
        }
        
        if (isBoss) 
        {
            Destroy(hitZone);
        }
        else if (!isHand)
        {
            Destroy(gameObject);
        }
        
    }

    IEnumerator BringOGColorsBack()
    {
        yield return new WaitForEndOfFrame();

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
        CanBossShoot(false);
        pd.playableGraph.GetRootPlayable(0).SetSpeed<Playable>(bossSlowMo);
        animator.speed -= 1f;
        yield return new WaitForSeconds(bossStunTime);

        bossEndPos = transform.position;
        bossEndPos.y -= 500;
        bossDefeated = true;
        pd.playableGraph.Stop();
        
    }

    void BossExit() 
    {
        
        transform.Translate(Vector3.down * bossFallSpeed, Space.World);
        transform.Rotate(Vector3.right * bossRotationSpeed, Space.World);

        if (transform.position.y < bossEndPos.y)
        {
            StartCoroutine(bossController.EndBossPhase());
        }
    }

    public void BossShoot()
    {
        if (canShoot && health > 0)
        {
            if (bossController.GetHandsDefeated() == 0)
            {
                Instantiate(bossProjectile, bossProjectileLocation.position, bossProjectileLocation.rotation);
            }
            else if (bossController.GetHandsDefeated() == 1)
            {
                int rando = UnityEngine.Random.Range(0, oddsOfShooting + 1);
                if (rando == oddsOfShooting) Instantiate(bossProjectile, bossProjectileLocation.position, bossProjectileLocation.rotation);
            }
            else
            {
                int rando = UnityEngine.Random.Range(0, oddsOfShooting);
                if (rando % 2 != 0) Instantiate(bossProjectile, bossProjectileLocation.position, bossProjectileLocation.rotation);     
            }
            
        }
        
    }

    public void CanBossShoot(bool state)
    {
        canShoot = state;
    }


    

}
