using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float health = 3;
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotateThrustForce = 100f;
    [SerializeField] float invincibilityTime = 2.5f;

    [Header("FrogScores")]
    [SerializeField] int frogCurrentLevelTotal = 0;
    [SerializeField] int frogGameTotal = 0;
    [SerializeField] Hashtable frogAmountSavedInEachLevel = new Hashtable();
    [SerializeField] Hashtable frogAmountInEachLevel = new Hashtable();

    //PLAYER HEALTH

    public float GetHealth()
    {
        return health;
    }

    public void LoseLife()
    {
        health -= 1;
    }

    //PLAYER STAT VALUES

    public float GetThrustForce() 
    {
        return thrustForce;
    }

    public float GetRotateThrustForce()
    {
        return rotateThrustForce;
    }

    public float GetInvincibilityTime()
    {
        return invincibilityTime;
    }

    public void SetFrogCurrentLevelAndGameTotal(int frogAmount, string level)
    {
        frogCurrentLevelTotal = frogAmount;
        frogGameTotal += frogCurrentLevelTotal;
        frogAmountInEachLevel[level] = frogAmount;
    }

}
