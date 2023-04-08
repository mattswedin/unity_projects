using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] dialogue;
    [SerializeField] bool isSpeaking;
    [SerializeField] int dialogueIndex;
    [SerializeField] float timeBetweenChars = .1f;

    PlayerController playerController;

    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        playerController.SetCantMove(true);
    }

    IEnumerator PlayDialogue() 
    {
        isSpeaking = true;
        
        for (int i = 0; i < dialogue[dialogueIndex].Length; i++)
        {
            char letter = dialogue[dialogueIndex][i];
            text.text += letter;
            yield return new WaitForSeconds(timeBetweenChars);
        }

        dialogueIndex++;

    }

   
}
