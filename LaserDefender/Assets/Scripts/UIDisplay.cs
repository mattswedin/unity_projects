using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

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
    [SerializeField] Sprite redShockedFace;
    [SerializeField] Sprite suckedFace;
    [SerializeField] Sprite powerUpFace;
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
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene == SceneManager.GetSceneByName("GameOver") ||
            currentScene == SceneManager.GetSceneByName("YouWon") )
        {
            Destroy(instance);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

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

    public void ChangeFace(string faceType) 
    {
        switch (faceType)
        {
            case "takeDamage":
                StartCoroutine(TakeDamageFace());
                break;
            case "shocked":
                faceDisplay.sprite = shockedFace;
                break;
            case "redShocked":
                faceDisplay.sprite = redShockedFace;
                break;
            case "sucked":
                faceDisplay.sprite = suckedFace;
                break;
            case "powerUp":
                faceDisplay.sprite = powerUpFace;
                break;
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
