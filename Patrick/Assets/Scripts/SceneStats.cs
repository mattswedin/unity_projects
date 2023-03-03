using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStats : MonoBehaviour
{
    FadeToBlack fadeToBlack;
    
    void Awake()
    {
       fadeToBlack = FindObjectOfType<FadeToBlack>();
    }

    
    void Start()
    {
       fadeToBlack.FadeOutBlack(); 
    }
}
