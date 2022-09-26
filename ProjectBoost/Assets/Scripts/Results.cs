using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Results : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI levelResult;

    FadeInOut fadeInOut;
    PlayerStats playerStats;

    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start()
    {
        fadeInOut.FadeOutBlack();
        SetUpResults();
    }

    void SetUpResults()
    {
        for (int i = 1; i < 4; i++)
        {
            double clearTime = Math.Round(playerStats.GetTimeLevel($"Level {i}"), 2);

        
            levelResult.text += $"Level {i}  Frogs: {playerStats.GetFrogCountCurrentLevel($"Level {i}")}/12 Time: {clearTime}";

        }
    }
}
