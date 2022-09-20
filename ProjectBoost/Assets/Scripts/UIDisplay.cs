using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
        if (sceneSwitcher.isBossLevel())
        {
            GetCurrentSceneBuildIndex();
            SetUpLife();
        }
        else if (!sceneSwitcher.IsFrogScore())
        {
            GetCurrentSceneBuildIndex();
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
        frogCount.text = "Frogs: 00";
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
        if (currentFrogAmount >= 10)
        {
            frogCount.text = "Frogs: " + currentFrogAmount;
        }
        else
        {
            frogCount.text = "Frogs: " + 0 + currentFrogAmount;
        }
    }

    public int GetFinishFrogPoints() 
    {
        return Int32.Parse(frogCount.text.Split(" ")[1]);
    }

    public void GetCurrentSceneBuildIndex()
    {
        sceneSwitcher.SetActiveSceneInt(SceneManager.GetActiveScene().buildIndex);
    }
}
