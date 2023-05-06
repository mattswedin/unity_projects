using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLightningController : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] Material fullAlphaMaterial;
    [SerializeField] Material transparentMaterial;
    [SerializeField] bool isFadedIn = false;


    void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        
        if (!isFadedIn) 
        {
            FadeInLighting();
        }
        else
        {
            FadeOutLighting();
        }
        
    }

    void FadeInLighting()
    {
        meshRenderer.material.Lerp(meshRenderer.material, fullAlphaMaterial, 2f * Time.deltaTime);

        if (Mathf.Round(meshRenderer.material.color.a * 10) / 10 ==
            Mathf.Round(fullAlphaMaterial.color.a * 10) / 10)
        {
            isFadedIn  = true;
            FadeOutLighting();
        }
    }

    void FadeOutLighting()
    {
        meshRenderer.material.Lerp(meshRenderer.material, transparentMaterial, 2f * Time.deltaTime);

        if (Mathf.Round(meshRenderer.material.color.a * 10) / 10 ==
            Mathf.Round(transparentMaterial.color.a * 10) / 10)
        {
            Destroy(gameObject);
        }
    }



}
