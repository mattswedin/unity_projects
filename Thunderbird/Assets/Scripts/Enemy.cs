using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Material[] hitColor;
    int hitColorIndex = 0;
    PlayerController playerController;
    List<Material> og = new List<Material>();
    MeshRenderer[] meshRenderers;
    bool ogMaterialsObtained;

    [Header("Enemy Type")]
    [SerializeField] bool isFlyingBetweenPoints;
    [SerializeField] Transform[] points;
    [SerializeField] int flyingSpeedBetweenPoints;
    int j = 0;
    

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    void Update() 
    {
       if (ogMaterialsObtained) BringOGColorsBack();
       if (isFlyingBetweenPoints) FlyingMovement();
    }

    void FlyingMovement()
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
        if (health < 1) Destroy(gameObject);
    }

    void BringOGColorsBack()
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = og[i];
        }
    }
}
