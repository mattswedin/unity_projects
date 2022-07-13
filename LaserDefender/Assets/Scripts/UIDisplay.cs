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
    [SerializeField] Sprite shockedFace;
    [SerializeField] Sprite suckedFace;
    static UIDisplay instance;

    

    void Awake() 
    {
        ManageSingleton();
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

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeFace(string action) 
    {
        if (action == "takeDamage")
        {
            StartCoroutine(TakeDamageFace());
        }
        else if (action == "shocked")
        {
            faceDisplay.sprite = shockedFace;
        }
        else if (action == "sucked") 
        {
            faceDisplay.sprite = suckedFace;
        }
        
    }

    public void NormalFace() 
    {
        faceDisplay.sprite = normalFace;
    }

    IEnumerator TakeDamageFace()
    {
        for (int i = 0; i < 1; i++)
        {
            faceDisplay.sprite = takeDamageFace;
            yield return new WaitForSeconds(faceTimeBeforeNormal);
        }
        NormalFace();
    }
}
