using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    string levelHighlighted = "";

    void Start()
    {
        
    }
 
    public void SwitchScene(string levelHighlighted) 
    {
        SceneManager.LoadScene(levelHighlighted);
    }

}
