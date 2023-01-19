using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI birdsCuredScore;
    GameStats gameStats;

    void Awake()
    {
        gameStats = FindObjectOfType<GameStats>();
    }

    void Update()
    {
        updateBirdScore();
    }

    void updateBirdScore()
    {
        //please optimize
        if (System.Int32.Parse(birdsCuredScore.text.Substring(12)) < System.Int32.Parse(gameStats.GetCurrentBirdsCured()))
        {
            birdsCuredScore.text = "Cured Birds: " + gameStats.GetCurrentBirdsCured();
        }
    }
}
