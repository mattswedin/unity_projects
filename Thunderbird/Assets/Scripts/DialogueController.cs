using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] dialogue;

    PlayerController playerController;

    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        playerController.SetCantMove(true);
    }

   
}
