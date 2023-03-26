using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI birdsCuredScore;
    [SerializeField] Slider healthSlider;
    [SerializeField] Image black;
    [SerializeField] float fadeSpeed = 1;
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

    public void Fade(bool fadeOut) 
    {
        if (fadeOut)
        {
            Debug.Log("FadeOut");
            black.CrossFadeAlpha(1, fadeSpeed, false);
        } 
        else
        {
            black.CrossFadeAlpha(0, fadeSpeed, false);
        }
    }
}
