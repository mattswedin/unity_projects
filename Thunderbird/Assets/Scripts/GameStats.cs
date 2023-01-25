using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float playerHealth = 100;
    [SerializeField] int currentBirdsCuredScore = 0;

    [Header("Current Level Stats")]
    [SerializeField] string levelName = "Violet Island";

    [Header("Enemy Stats")]
    [SerializeField] float firePower = .5f;
    [SerializeField] float enemyBumpPower = 10f;

    //Health

    public void LoseHealth(string type)
    {
        if (type == "Fire")
        {
            playerHealth -= firePower;
        }
        else if (type == "Enemy")
        {
            playerHealth -= enemyBumpPower;
        }
        
    }

    public float GetHealth()
    {
        return playerHealth;
    }

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
