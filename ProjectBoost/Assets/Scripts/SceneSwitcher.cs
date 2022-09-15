using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    PlayerStats playerStats;
    int ActiveSceneInt;
    [SerializeField] float endOfLevelDelay = 1f;

    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void SetActiveSceneInt(int scene)
    {
        ActiveSceneInt = scene;
    }

    public void LoadNextLevel()
    {  
        SceneManager.LoadScene(ActiveSceneInt + 1);   
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
