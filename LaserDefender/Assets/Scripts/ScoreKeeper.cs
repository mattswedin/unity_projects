using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] float currentScore = 000000;
    [SerializeField] float currentHighScore = 0f;
    [SerializeField] GameObject powerUp;
    static ScoreKeeper instance;

    void Awake() 
    {
        ManageSingleton();
    }

    void Update() 
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

    void PowerUpSpawn() 
    {
        if (currentScore > currentHighScore + 500)
        {
            if (powerUp != null)
            {
                float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                Vector3 spawnPosition = new Vector3(spawnX, spawnY);

                Instantiate(powerUp, spawnPosition, Quaternion.identity);
            }
            
        }
    }
}
