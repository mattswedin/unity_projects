using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float playerHealth = 100;
    [SerializeField] int currentBirdsCuredScore = 0;
    [SerializeField] int laserBasePower = 1;
    [SerializeField] int laserPowerUpPower = 1;
    [SerializeField] int laserLevel = 0;

    [Header("Current Level Stats")]
    [SerializeField] string levelName = "Violet Island";

    [Header("All Level Stats")]
    [SerializeField] Dictionary<string, int> birdsCured;

    [Header("Boss: Spiral Eyes")]
    [SerializeField] float damageDoneSpiralEyes = 0;

    //Health
    public void LoseHealth(float damage)
    {
        playerHealth -= damage;
    }

    public float GetHealth()
    {
        return playerHealth;
    }

    //Attack


    public void PowerUp()
    {
        laserLevel += 1;
        laserPowerUpPower += 1;
    }

    public int GetLaserPower()
    {
        return laserBasePower * laserPowerUpPower;
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

    public int GetLaserLevel()
    {
        return laserLevel;
    }

}
