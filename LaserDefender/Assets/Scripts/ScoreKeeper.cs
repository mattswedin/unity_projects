using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;

    public int GetCurrentScore() 
    {
        return currentScore;
    }

    public void AddToScore(int amount) 
    {
        currentScore += amount;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore() 
    {
        currentScore = 0;
    }
}
