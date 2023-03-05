using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStats : MonoBehaviour
{
    FadeToBlack fadeToBlack;
    GameStats gameStats;
    
    void Awake()
    {
      gameStats = FindObjectOfType<GameStats>();
      fadeToBlack = FindObjectOfType<FadeToBlack>();
    }

    void Start()
    {
      gameStats.SetCanClick();
      fadeToBlack.FadeOutBlack(); 
    }
}
