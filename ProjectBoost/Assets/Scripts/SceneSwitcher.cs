using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField] float endOfLevelDelay = 1f;

    int currentLevel;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "FrogScore")
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }
        
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);   
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

    public string GetCurrentLevelName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
