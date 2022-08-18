using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI life;
    [SerializeField] TextMeshProUGUI frogCount;

    SceneSwitcher sceneSwitcher;
    PlayerStats playerStats;


    void Awake() 
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        if (!sceneSwitcher.IsFrogScore())
        {
            SetUpFrogCounts();
            SetUpLife();
        }
    }

    void Update() 
    {
        LoseLife();
    }

    void SetUpFrogCounts() 
    {
        int frogTotalinCurrentScene = GameObject.Find("Frogs").transform.childCount;
        playerStats.SetFrogCurrentLevelTotal(frogTotalinCurrentScene, 
                                                    sceneSwitcher.GetCurrentLevelName());
        frogCount.text = "Frogs: 0";
    }
    
    void SetUpLife ()
    {
        for(int i = 0; i < playerStats.GetHealth(); i++)
        {
            life.text += "(";
        }
    }

    void LoseLife() 
    {
        if (playerStats.GetHealth() < life.text.Length)
        {
            life.text = life.text.Remove(life.text.Length - 1);
        }
    }

    public void AddFrogPoint() 
    {
        int currentFrogAmount = Int32.Parse(frogCount.text.Split(" ")[1]);
        currentFrogAmount += 1;
        frogCount.text = "Frogs: " + currentFrogAmount;
    }

    public int GetFinishFrogPoints() 
    {
        return Int32.Parse(frogCount.text.Split(" ")[1]);
    }
}
