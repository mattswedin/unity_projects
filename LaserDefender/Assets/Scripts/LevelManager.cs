using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float gameOverDelayTime = .5f;
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

    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad(2, gameOverDelayTime));
        

    }

    public void QuitGame() 
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    IEnumerator WaitandLoad(int sceneInt, float delay) 
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneInt);
    }
}
