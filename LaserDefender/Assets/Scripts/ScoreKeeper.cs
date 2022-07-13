using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float currentScore = 000000;
    static ScoreKeeper instance;

    void Awake() 
    {
        ManageSingleton();
    }

    void Start() 
    {

    }

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

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
