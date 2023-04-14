using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour
{
    [SerializeField] string sceneToWarp;

    void Start()
    {
        SceneManager.LoadScene(sceneToWarp);
    }

}
