using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("Character Name")]
    [SerializeField] string charName;

    [Header("Beginning Dialogue")]
    [SerializeField] string dialogue;
    [SerializeField] bool inConversation = false;
    [SerializeField] int convoIndex = 0;
    string[] lines;

    UIController uIController;

    void Awake() 
    {
        uIController = FindObjectOfType<UIController>();
    }

    private void Start() 
    {
        lines = dialogue.Split("*");
    }

    private void OnMouseDown() 
    {
        if (!inConversation)
        {
            uIController.SetName(charName);
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
                uIController.ClearText();
                inConversation = false;
                convoIndex = 0;
            }

            string line = lines[convoIndex];
            StartCoroutine(uIController.SpeakLine(line));
        }
    }

}
