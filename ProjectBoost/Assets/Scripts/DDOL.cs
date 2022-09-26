using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
