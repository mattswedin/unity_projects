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

    [Header("All Level Stats")]
    [SerializeField] Dictionary<string, int> birdsCured;

    [Header("Boss: Spiral Eyes ")]
    [SerializeField] float damageDoneSpiralEyes = 0;

    //Health

    public void LoseHealth(string type)
    {
     
    }

    public void LoseHealthTest(float damage)
    {
        playerHealth -= damage;
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
