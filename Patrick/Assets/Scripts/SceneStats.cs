using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStats : MonoBehaviour
{
    FadeToBlack fadeToBlack;
    GameStats gameStats;

    void Start()
    {
      gameStats = FindObjectOfType<GameStats>();
      fadeToBlack = FindObjectOfType<FadeToBlack>();
      gameStats.SetCanClick();
      fadeToBlack.FadeOutBlack(); 
    }
}
