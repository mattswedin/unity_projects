using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float playerHealth = 100;
    [SerializeField] int currentBirdsCuredScore = 0;
    [SerializeField] double birdsCuredUntilPowerUp = 5;
    [SerializeField] float laserBasePower = 0.1f;
    [SerializeField] bool maxPower = false;
    [SerializeField] float laserPowerUpPower = 0;

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
        if (playerHealth <= 0) Death();
    }

    public float GetHealth()
    {
        return playerHealth;
    }

    //Attack


    public void PowerUp()
    {
        laserPowerUpPower += .1f;
    }

    public float GetLaserPower()
    {
        return laserBasePower + laserPowerUpPower;
    }

    //Score

    public void SetBirdsCured()
    {
        currentBirdsCuredScore += 1;
        if (currentBirdsCuredScore >= birdsCuredUntilPowerUp && !maxPower)
        {
            PowerUp();
            if (birdsCuredUntilPowerUp == 15)
            {
                maxPower = true;
            } 
            else
            {
                birdsCuredUntilPowerUp += 5;
            }
        }
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

    public void SpiralEyesDamage(float amount) 
    {
        damageDoneSpiralEyes += amount;
    }

    void Death() 
    {
        Debug.Log("YOU DIED");
    }

}
