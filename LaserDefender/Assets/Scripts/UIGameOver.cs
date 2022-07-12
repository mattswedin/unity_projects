using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreDisplay.text = "SCORE:\n" + scoreKeeper.GetCurrentScore();
    }

}
