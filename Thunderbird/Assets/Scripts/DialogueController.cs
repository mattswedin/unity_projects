using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueObj;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] dialogue;
    [SerializeField] bool isSpeaking;
    [SerializeField] int dialogueIndex;
    [SerializeField] float timeBetweenSents = 1f;

    TimelineManager timelineManager;
    PlayerController playerController;

    void Awake() 
    {
        timelineManager = FindObjectOfType<TimelineManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        dialogueObj.SetActive(true);
        playerController.SetCantMove(true);
       PlayDialogue();
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

                text.text = dialogue[dialogueIndex];

            isSpeaking = false;

            yield return new WaitForSeconds(timeBetweenSents);
        }
        else
        {
            timelineManager.EndCurrentTimeline();
            ClearText();
        }
    }

    public void ClearText() 
    {
        text.text = "";
        dialogueObj.SetActive(false);
    }

   
}
