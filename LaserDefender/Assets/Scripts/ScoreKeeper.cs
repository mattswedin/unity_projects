using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float currentScore = 000000;

    public float GetCurrentScore() 
    {
        return currentScore;
    }

    public void AddToScore(float amount) 
    {
        currentScore += amount;
        Mathf.Clamp(currentScore, 000000, 999999);
        Debug.Log(currentScore);
    }

    public void ResetScore() 
    {
        currentScore = 000000;
    }
}
