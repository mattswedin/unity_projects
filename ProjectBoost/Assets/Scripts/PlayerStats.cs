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
    [SerializeField] float deathCount = 0;
    float defaultHealth;
    bool canDie = true;

    [Header("Frog Scores")]
    [SerializeField] Hashtable frogAmountSavedInEachLevel = new Hashtable();
    [SerializeField] Hashtable frogAmountInEachLevel = new Hashtable();

    [Header("Time Score")]
    [SerializeField] Hashtable timeInEachLevel = new Hashtable();

    [Header("Level Information")]
    [SerializeField] string lastLevelCompleted;

    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;

    void Awake() 
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start()
    {
        defaultHealth = health;
    }

    void Update() 
    {
        if (health == 0 && canDie)
        {
            Die();
        }
    }

    //PLAYER HEALTH

    public float GetHealth()
    {
        return health;
    }

    public void GainLife()
    {
        health += 1;
    }

    public void LoseLife()
    {
        health -= 1;
    }

    public void RestartHealth()
    {
        health = defaultHealth;
        canDie = true;
    }

    void Die()
    {
        canDie = false;
        if (!sceneSwitcher.isBossLevel())
        {
            deathCount += 1;
        }
        Player player = FindObjectOfType<Player>();
        player.SetCantMove(true);
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(sceneSwitcher.ToContinue());
    }

    public float GetDeathCount()
    {
        return deathCount;
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

    //FROG SCORES

    public int GetFrogCurrentLevelTotal(string level)
    {
        return (int)frogAmountInEachLevel[level];
    }

    public void SetFrogCurrentLevelTotal(int frogAmount, string level)
    {
        frogAmountInEachLevel[level] = frogAmount;
        lastLevelCompleted = level;
    }

    public int GetFrogCountCurrentLevel(string level)
    {
        return (int)frogAmountSavedInEachLevel[level];
    }

    public void SetFrogCountCurrentLevel(int frogAmount, string level)
    {
        frogAmountSavedInEachLevel[level] = frogAmount;
    }

    public int GetFrogTotalCount()
    {
        int total = 0;

        for(int i = 1; i < frogAmountSavedInEachLevel.Count + 1; i++)
        {
            total += (int)frogAmountSavedInEachLevel[$"Level {i}"];
        }
        
        return total;
    }

    //Time Scores

    public void SetTimeCurrentLevel(float time, string level)
    {
        timeInEachLevel[level] = time;
    }

    public float GetTimeLevel(string level)
    {
        return (float)timeInEachLevel[level];
    }


    //LEVEL INFO

    public string GetLastLevelCompleted()
    {
        return lastLevelCompleted;
    }

    public int GetLevelsCompleted()
    {
        return timeInEachLevel.Count;
    }


}
