using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;
    void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
        fadeInOut.FadeOutBlack();

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
