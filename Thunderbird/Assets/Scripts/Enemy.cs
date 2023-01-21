using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    

    PlayerController playerController;
    GameStats gameStats;
    
    

    void Awake()
    {
        gameStats = FindObjectOfType<GameStats>();
        playerController = FindObjectOfType<PlayerController>();
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    void Update() 
    {
       if (ogMaterialsObtained) BringOGColorsBack();
       if (isFlyingBetweenPoints) PositionMovement();
       if (isRotatingBetweenPoints) RotationMovement();
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
        health -= playerController.GetLaserPower();
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
            if (deathExplosion != null) Instantiate(deathExplosion, transform.position, transform.rotation);

            if (normalVersion != null)
            {
                GameObject normie = Instantiate(normalVersion, transform.position, transform.rotation);
                normie.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
            } 
            died = true;
            gameStats.SetBirdsCured();
        }
        
        Destroy(gameObject);
    }

    void BringOGColorsBack()
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = og[i];
        }
    }

    public float GetAttackPower()
    {
        return attackPower;
    }
}
