using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Fly In")]
    [SerializeField] Vector3 startingPos;
    [SerializeField] float flyInSpeed = 10f;

    [Header("Movement")]
    float xThrow, yThrow;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRangeTop = 10f;
    [SerializeField] float yRangeBottom = -3f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2;
    [SerializeField] float controlRollFactor = 5;
    float xMovement;
    float yMovement;
    bool canMove = false;

    [Header("Lasers")]
    [SerializeField] GameObject lasers;
    [SerializeField] int laserBasePower = 1;
    [SerializeField] int laserPowerUpPower = 1;
    [SerializeField] string laserLevelName;
    bool needToSwitchLasers = true;
    Transform laserLevel;

    GameStats gameStats;
    Enemy enemy;
    EnemyProjectile enemyProjectile;

    void Awake() 
    {   
        gameStats = FindObjectOfType<GameStats>();
    }

    void Start() 
    {
        laserLevelName = lasers.transform.GetChild(gameStats.GetLaserLevel()).name;
    }

    void Update()
    {
        if (needToSwitchLasers) SwitchLasers(gameStats.GetLaserLevel());

        if (!canMove) 
        {
            FlyIntoView();
        }
        else
        {
            Fly();
            FlyRotation();  
        }

        Shoot();
    }

    void Shoot() 
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateLasers(true);
        }
        else
        {
            ActivateLasers(false);
        }
    }

    void ActivateLasers(bool state) 
    {
        laserLevel = lasers.transform.GetChild(gameStats.GetLaserLevel());

        if (laserLevelName != laserLevel.name)
        {
            needToSwitchLasers = true;
            laserLevelName = laserLevel.name;
        } 

        for(int i = 0; i < laserLevel.childCount; i++)
        {
            GameObject laser = laserLevel.GetChild(i).gameObject;
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }

    void FlyIntoView()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, startingPos, flyInSpeed * Time.deltaTime);

        if (transform.localPosition == startingPos)
        {
            canMove = true;
            return;
        }
    }

    void Fly() 
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        xMovement = xThrow * Time.deltaTime * moveSpeed;
        yMovement = yThrow * Time.deltaTime * moveSpeed;
        float xClamp = Mathf.Clamp(transform.localPosition.x 
                                + xMovement, -xRange, xRange);
        float yClamp = Mathf.Clamp(transform.localPosition.y 
                                + yMovement, yRangeBottom, yRangeTop);
        Vector3 newMovement = new Vector3(xClamp, yClamp, 0);

        transform.localPosition = new Vector3(newMovement.x, newMovement.y, transform.localPosition.z);
    }

    void FlyRotation() 
    {
        float pitchDueToPos = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float pitch =  pitchDueToPos + pitchDueToControl;
        float roll = xThrow * controlRollFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    void OnParticleCollision(GameObject other) 
    {
        if (other.tag == "Enemy")
        {
            enemyProjectile = other.gameObject.GetComponentInParent<EnemyProjectile>();
            gameStats.LoseHealth(enemyProjectile.GetAttackPower());
        }  
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponentInParent<Enemy>();
            gameStats.LoseHealth(enemy.GetAttackPower());
        }
    }

    void SwitchLasers(int laserLevel)
    {
        for(int i = 0; i < lasers.transform.childCount; i++)
        {
            lasers.transform.GetChild(i).gameObject.SetActive(false);
        }

        lasers.transform.GetChild(laserLevel).gameObject.SetActive(true);

        needToSwitchLasers = false;
        
    }
}
