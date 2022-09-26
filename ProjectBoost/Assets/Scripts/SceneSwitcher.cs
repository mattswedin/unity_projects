using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    PlayerStats playerStats;
    int ActiveSceneInt;
    FadeInOut fadeInOut;

    [SerializeField] string lastScene;
    [SerializeField] float endOfLevelDelay = 1f;
    [SerializeField] float dieDelay = 1.6f;

    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex ==  0)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator ToContinue()
    {
        lastScene = SceneManager.GetActiveScene().name;

        yield return new WaitForSecondsRealtime(dieDelay);
        fadeInOut.CutToBlack();
        yield return new WaitForSecondsRealtime(.5f);
        playerStats.RestartHealth();
        SceneManager.LoadScene("Continue");
        
    }

    public IEnumerator RestartLevel()
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(lastScene);
    }

    public IEnumerator ToResultDisplay()
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Results");
    }

    public void SetActiveSceneInt(int scene)
    {
        ActiveSceneInt = scene;
    }

    public IEnumerator LoadNextLevel()
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(ActiveSceneInt + 1);   
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public IEnumerator LoadFrogScoreScene()
    {
        fadeInOut.FadeInBlack();
        yield return new WaitForSeconds(endOfLevelDelay);
        SceneManager.LoadScene("FrogScore");
    }

    public bool IsFrogScore()
    {
        if (SceneManager.GetActiveScene().name == "FrogScore")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isBossLevel()
    {
        if (SceneManager.GetActiveScene().name == "Boss")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isContinueLevel()
    {
        if (SceneManager.GetActiveScene().name == "Continue")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetCurrentLevelName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
