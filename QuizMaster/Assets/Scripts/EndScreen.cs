using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI finalMessageText;
    ScoreKeeper scoreKeeper;
   
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "Your final score is " + scoreKeeper.CalculateScore() + "%";

        if (scoreKeeper.CalculateScore() == 100)
        {
            finalMessageText.text = "You are the true SNAKEMASTER!!";
        }
        else
        {
            finalMessageText.text = "You were close...NOT!!";
        }
    }

}
