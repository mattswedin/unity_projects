using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("Character Name")]
    [SerializeField] string charName;
    [SerializeField] GameObject openMouthAni;
    SpriteRenderer spriteRenderer;
    [SerializeField] Color opaqueOpenMouth;
    [SerializeField] Color transparentOpenMouth;

    [Header("Dialogue")]
    [SerializeField] string dialogue;
    [SerializeField] bool inConversation = false;
    [SerializeField] bool isSpeakingLine = false;
    [SerializeField] int convoIndex = 0;
    string[] lines;
    

    DialogueManager dialogueManager;
    GameStats gameStats;

    void Awake() 
    {
        gameStats = FindObjectOfType<GameStats>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Start() 
    {
        lines = dialogue.Split("*");
    }

    private void OnMouseDown() 
    {
        if (gameStats.GetCanClick(gameObject.name)) 
        {
            if (isSpeakingLine) 
            {
                Debug.Log("speedup");
                dialogueManager.SpeedUpText();
                return;
            } 

            if (!inConversation)
            {
                dialogueManager.SetName(charName);
                inConversation = true;
            }
            else
            {
                if (convoIndex != lines.Length - 1)
                {
                    convoIndex++;
                }
                else
                {
                    dialogueManager.ClearText();
                    inConversation = false;
                    convoIndex = 0;
                    return;
                }
            }
        string line = lines[convoIndex];
        StartCoroutine(dialogueManager.SpeakLine(line));
        }
    }

    public void SetIsSpeakingLine(bool state) 
    {
        isSpeakingLine = state;
    }

    public void SetMouthAnimation(bool state) 
    {
       if (spriteRenderer == null) spriteRenderer = openMouthAni.GetComponent<SpriteRenderer>();

        spriteRenderer.color = state ? opaqueOpenMouth : transparentOpenMouth;
    }

}
