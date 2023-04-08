using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueObj;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] dialogue;
    [SerializeField] bool isSpeaking;
    [SerializeField] int dialogueIndex;
    [SerializeField] float timeBetweenChars = .1f;
    [SerializeField] float defaultTimeBetweenChars = .1f;
    [SerializeField] GameObject nextScene;

    PlayerController playerController;

    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        dialogueObj.SetActive(true);
        playerController.SetCantMove(true);
        StartCoroutine(PlayDialogue());
    }

    void Update() 
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isSpeaking)
            {
                dialogueIndex++;
                StartCoroutine(PlayDialogue());
            }
        }
    }

    IEnumerator PlayDialogue() 
    {
        
        text.text = "";

        if (dialogueIndex < dialogue.Length)
        {
            isSpeaking = true;

            for (int i = 0; i < dialogue[dialogueIndex].Length; i++)
            {
                char letter = dialogue[dialogueIndex][i];
                text.text += letter;
                if (letter != ' ') yield return new WaitForSeconds(timeBetweenChars);
            }

            isSpeaking = false;
        }
        else
        {
            nextScene.SetActive(true);
        }

       
    }

   
}
