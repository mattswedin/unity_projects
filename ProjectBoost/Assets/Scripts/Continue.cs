using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    FadeInOut fadeInOut;
    // Start is called before the first frame update
    void Awake()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start() 
    {
        fadeInOut.FadeOutBlack();
    }

    public void RestartCurrentLevel()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart() 
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(1f);
        sceneSwitcher.RestartLevel();
    }
}
