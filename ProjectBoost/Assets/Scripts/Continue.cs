using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    void Awake()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    public void RestartCurrentLevel()
    {
        sceneSwitcher.RestartLevel();
    }
}
