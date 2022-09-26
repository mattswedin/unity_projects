using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;
    
    void Awake()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start() 
    {
        fadeInOut.FadeOutBlack();
    }

    public void RestartCurrentLevel()
    {
        StartCoroutine(sceneSwitcher.RestartLevel());
    }

    public void ToResults()
    {
        StartCoroutine(sceneSwitcher.ToResultDisplay());
    }

}
