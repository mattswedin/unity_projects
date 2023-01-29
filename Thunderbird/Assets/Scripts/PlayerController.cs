using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Fly In")]
    [SerializeField] Vector3 startingPos;

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
    bool hasFlownIn = false;

    [Header("Lasers")]
    [SerializeField] GameObject[] lasers;
    [SerializeField] int laserBasePower = 1;

    GameStats gameStats;
    Enemy enemy;

    void Awake() 
    {
        gameStats = FindObjectOfType<GameStats>();
    }

    void Update()
    {
        if (hasFlownIn) 
        {
            Fly();
            FlyRotation();
            Shoot(); 
        }
        else
        {
            FlyIntoView();  
        }
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
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }

    void FlyIntoView()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, startingPos, moveSpeed * Time.deltaTime);

        if (transform.localPosition == startingPos)
        {
            hasFlownIn = true;
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

    public int GetLaserPower()
    {
        return laserBasePower;
    } 

    void OnParticleCollision(GameObject other) 
    {
        if (other.tag == "Fire")
        {
            gameStats.LoseHealth("Fire"); 
        }  
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameStats.LoseHealth("Enemy");
        }
    }
}
