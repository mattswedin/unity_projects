using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    PlayerStats playerStats;
    int ActiveSceneInt;
    [SerializeField] string lastScene;
    [SerializeField] float endOfLevelDelay = 1f;

    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex ==  0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator ToContinue()
    {
        lastScene = SceneManager.GetActiveScene().name;

        yield return new WaitForSecondsRealtime(1.3f);
        playerStats.RestartHealth();
        SceneManager.LoadScene("Continue");
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(lastScene);
    }

    public void SetActiveSceneInt(int scene)
    {
        ActiveSceneInt = scene;
    }

    public void LoadNextLevel()
    {  
        SceneManager.LoadScene(ActiveSceneInt + 1);   
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public IEnumerator LoadFrogScoreScene()
    {
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
