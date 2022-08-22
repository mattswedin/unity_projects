using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinishPad : MonoBehaviour
{
    UIDisplay uIDisplay;
    SceneSwitcher sceneSwitcher;
    PlayerStats playerStats;

    void Awake() 
    {
        uIDisplay = FindObjectOfType<UIDisplay>();
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        playerStats = FindObjectOfType<PlayerStats>();
    }
    
    void Update()
    {
        if (uIDisplay.GetFinishFrogPoints() == playerStats.GetFrogCurrentLevelTotal(sceneSwitcher.GetCurrentLevelName())) 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
