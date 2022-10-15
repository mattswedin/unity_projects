using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Continue : MonoBehaviour
{
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    bool yesIsSelected = true;

    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;
    
    
    void Awake()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start() 
    {
        fadeInOut.FadeOutBlack();
        yesButton.Select();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (yesIsSelected)
            {
                noButton.Select();
                yesIsSelected = false;
            }
            else
            {
                yesButton.Select();
                yesIsSelected = true;
            }
        }
    }



    public void RestartCurrentLevel()
    {
        StartCoroutine(sceneSwitcher.RestartLevel());
    }

    public void ToResults()
    {
        StartCoroutine(sceneSwitcher.ToResultDisplay());
    }

}
