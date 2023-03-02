using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI birdsCuredScore;
    [SerializeField] Slider healthSlider;
    GameStats gameStats;

    void Awake()
    {
        gameStats = FindObjectOfType<GameStats>();
    }

    void Start() 
    {
        healthSlider.maxValue = gameStats.GetHealth();
    }

    void Update()
    {
        updateBirdScore();
        updateHealth();
    }

    void updateBirdScore()
    {
        //please optimize
        if (System.Int32.Parse(birdsCuredScore.text.Substring(12)) < System.Int32.Parse(gameStats.GetCurrentBirdsCured()))
        {
            birdsCuredScore.text = "Cured Birds: " + gameStats.GetCurrentBirdsCured();
        }
    }

    void updateHealth()
    {
        if (gameStats.GetHealth() != healthSlider.value)
        {
            healthSlider.value = gameStats.GetHealth();
        }
    }
}