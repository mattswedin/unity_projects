using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float gameOverDelayTime = .5f;
    [SerializeField] float nextLevelDelayTime = 2f;
    ScoreKeeper scoreKeeper;
    

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame() 
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitandLoadNextLevel(currentScene + 1, nextLevelDelayTime));
    }

    IEnumerator WaitandLoadNextLevel(int sceneInt, float delay)
    {
        yield return new WaitForSeconds(nextLevelDelayTime);
        SceneManager.LoadScene(sceneInt);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoadGameOver("GameOver", gameOverDelayTime));
    }

    IEnumerator WaitandLoadGameOver(string scene, float delay)
    {
        yield return new WaitForSeconds(gameOverDelayTime);
        SceneManager.LoadScene(scene);
    }



    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }


}
