using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Results : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI levelResult;
    [SerializeField] TextMeshProUGUI resultResult;
    [SerializeField] int numberOfCompleted = 0;

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
        SetUpDeathsResult();
    }

    void SetUpResults()
    {
        for (int i = 1; i < playerStats.GetLevelsCompleted() + 1; i++)
        {
            int clearTime = Convert.ToInt32(Math.Round(playerStats.GetTimeLevel($"Level {i}")));
            string clearTimeString;

            
            if (clearTime.ToString().Length == 2) 
            {
                if (clearTime >= 60)
                {
                    int remaining = clearTime - 60;

                    if (remaining > 9)
                    {
                        clearTimeString = "1" + ":" + remaining.ToString();
                    }
                    else
                    {
                        clearTimeString = "1" + ":" + "0" + remaining.ToString();
                    }
                }
                else
                {
                    clearTimeString = "0" + ":" + clearTime.ToString();
                }

            }
            else if (clearTime <= 575)
            {
               string num = (clearTime / 60).ToString();
               char wholeNum = num[0];
               int decNum = clearTime % 60;
               if (decNum > 9)
               {
                    clearTimeString = wholeNum + ":" + decNum;
               }
               else
               {
                    clearTimeString = wholeNum + ":0" + decNum;
               }
            }
            else
            {
                clearTimeString = "TIMEOUT";
            }

            if (playerStats.GetFrogCountCurrentLevel($"Level {i}") == 12)
            {
                numberOfCompleted += 1;
            }

            levelResult.text += $"Level {i}   Frogs: {playerStats.GetFrogCountCurrentLevel($"Level {i}")}/12   Time: {clearTimeString}";
            levelResult.text += System.Environment.NewLine;
            levelResult.text += System.Environment.NewLine;
        }
    }

    void SetUpDeathsResult() 
    {
        resultResult.text = $"Deaths: {playerStats.GetDeathCount()}    ";

        if (numberOfCompleted == 3 && playerStats.GetDeathCount() == 0)
        {
            resultResult.text += "YOU ARE TRULY FROG SAVIOR!";
        }
        else if (numberOfCompleted == 3)
        {
            resultResult.text += "EVERY FROG SAVED!";
        }
        else
        {
            resultResult.text += "FROGS DIED BECAUSE OF YOUR CARELESSNESS...";
        }
    }
}
