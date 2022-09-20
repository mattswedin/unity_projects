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
    float defaultHealth;
    bool canDie = true;

    [Header("Frog Scores")]
    [SerializeField] Hashtable frogAmountSavedInEachLevel = new Hashtable();
    [SerializeField] Hashtable frogAmountInEachLevel = new Hashtable();

    [Header("Level Information")]
    [SerializeField] string lastLevelCompleted;

    SceneSwitcher sceneSwitcher;

    void Awake() 
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
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
        GameObject player = GameObject.Find("Robot (Player)");
        player.GetComponent<Player>().SetCantMove(true);
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(sceneSwitcher.ToContinue());
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

   

    //LEVEL INFO

    public string GetLastLevelCompleted()
    {
        return lastLevelCompleted;
    }


}
