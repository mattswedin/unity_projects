using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Material[] hitColor;
    PlayerController playerController;
    List<Material> og = new List<Material>();
    MeshRenderer[] meshRenderers;
    bool ogObtained;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    void Update() 
    {
       if (ogObtained) BringOGColorsBack();
    }

    void OnParticleCollision(GameObject other) 
    {
        int rando = Random.Range(0, hitColor.Length); 
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            MeshRenderer mesh = meshRenderers[i];
            og.Add(mesh.material);
            mesh.material = hitColor[rando];
        }
        if (!ogObtained) ogObtained = true;
        health -= playerController.GetLaserPower();
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
