using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    
    [SerializeField] bool FadeOut;
    UIController uIController;

    void Awake() 
    {
        uIController = FindObjectOfType<UIController>();
    }

    void Start()
    {
        uIController.Fade(FadeOut);
    }

}
