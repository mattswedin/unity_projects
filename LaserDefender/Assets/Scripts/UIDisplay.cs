using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] Slider healthDisplay;
    [SerializeField] Image faceDisplay;
    [SerializeField] Health health;
    [SerializeField] float faceTimeBeforeNormal = 0.5f;
    ScoreKeeper scoreKeeper;
    [SerializeField] Sprite normalFace;
    [SerializeField] Sprite takeDamageFace;
    

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    void Start() 
    {
        healthDisplay.maxValue = health.GetRemainingHealth();
    }

    void Update() 
    {
        healthDisplay.value = health.GetRemainingHealth();
        scoreDisplay.text = scoreKeeper.GetCurrentScore().ToString("000000");
    }

    public void ChangeFace(string action) 
    {
        if (action == "takeDamage")
        {
            StartCoroutine(TakeDamageFace(takeDamageFace));
        }
    }

    IEnumerator TakeDamageFace(Sprite facePicture)
    {
        for (int i = 0; i < 1; i++)
        {
            faceDisplay.sprite = takeDamageFace;
            yield return new WaitForSeconds(faceTimeBeforeNormal);
        }
        faceDisplay.sprite = normalFace;
    }
}
