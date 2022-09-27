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
        for (int i = 1; i < playerStats.GetLevelsCompleted() + 1; i++)
        {
            int clearTime = Convert.ToInt32(Math.Round(playerStats.GetTimeLevel($"Level {i}")));
            string clearTimeString;

            Debug.Log(clearTime);
            
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

            levelResult.text += $"Level {i}   Frogs: {playerStats.GetFrogCountCurrentLevel($"Level {i}")}/12   Time: {clearTimeString}";
            levelResult.text += System.Environment.NewLine;
            levelResult.text += System.Environment.NewLine;
        }
    }
}
