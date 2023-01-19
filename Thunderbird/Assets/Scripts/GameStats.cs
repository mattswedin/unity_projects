using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] int playerHealth = 100;
    [SerializeField] int currentBirdsCuredScore = 0;

    [Header("Current Level Stats")]
    [SerializeField] string levelName = "Violet Island";

    //Score

    public void SetBirdsCured()
    {
        currentBirdsCuredScore += 1;
    }

    public string GetCurrentBirdsCured()
    {
        if (currentBirdsCuredScore.ToString().Length == 1)
        {
            return $"0{currentBirdsCuredScore}";
        }
        else
        {
            return currentBirdsCuredScore.ToString();
        }
    }
}
