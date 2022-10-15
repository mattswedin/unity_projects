using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    bool startIsSelected = true;

    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;

    void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
        fadeInOut.FadeOutBlack();
        startButton.Select();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (startIsSelected)
            {
                quitButton.Select();
                startIsSelected = false;
            }
            else
            {
                startButton.Select();
                startIsSelected = true;
            }
        }
    }

    public void StartFirstLevel()
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(1f);
        sceneSwitcher.LoadFirstLevel();
    }

}
