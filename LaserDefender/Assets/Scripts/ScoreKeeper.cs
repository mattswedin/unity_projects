using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] float currentScore = 000000;
    [SerializeField] float currentHighScore = 0f;
    [SerializeField] GameObject powerUp;
    static ScoreKeeper instance;
    Player playerScript;

    void Awake() 
    {
       
        ManageSingleton();
    }

    void Update() 
    {
       
        
        PowerUpSpawn();
        
        
    }

    public float GetCurrentScore() 
    {
        return currentScore;
    }

    public void AddToScore(float amount) 
    {
        playerScript = FindObjectOfType<Player>();
        
        if (!playerScript.getPoweredUp())
        {
            currentScore += amount;
        }
        else
        {
            currentScore += amount;
            currentHighScore = currentScore;
        }

        Mathf.Clamp(currentScore, 000000, 999999);
        Mathf.Clamp(currentHighScore, 000000, 999999);

        
    }

    public void ResetScore() 
    {
        currentScore = 000000;
        currentHighScore = 000000;
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
        if (currentScore >= (currentHighScore + 500))
        {
            if (powerUp != null && !playerScript.isFinalBoss())
            {
                GameObject instance = Instantiate(powerUp, transform.position + new Vector3(0, 7, 0), Quaternion.identity);
                currentHighScore = currentScore;
                DontDestroyOnLoad(instance);
                instance.GetComponent<Rigidbody2D>().velocity = -transform.up;
            }
            
        }
    }

}
