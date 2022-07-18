using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] float currentScore = 000000;
    [SerializeField] float currentHighScore = 0f;
    [SerializeField] GameObject powerUp;
    [SerializeField] int powerUpsLeft = 2;
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
        if (playerScript == null)
        {
            playerScript = FindObjectOfType<Player>();
        }
        

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
        if (currentScore >= currentHighScore + 500 && powerUpsLeft > 0)
        {
            if (powerUp != null)
            {
                GameObject instance = Instantiate(powerUp, transform.position + new Vector3(0, 7, 0), Quaternion.identity);
                DontDestroyOnLoad(instance);
                instance.GetComponent<Rigidbody2D>().velocity = -transform.up;
            }
            powerUpsLeft -= 1;
            
        }
    }

}
