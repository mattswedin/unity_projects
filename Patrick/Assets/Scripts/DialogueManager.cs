using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Image textBox;
    [SerializeField] float textBoxFadeSpeed = 100f;
    [SerializeField] Color textBoxColor;
    [SerializeField] TextMeshProUGUI charName;
    [SerializeField] TextMeshProUGUI charText;
    [SerializeField] float standardTextSpeed = .1f;
    [SerializeField] float textSpeed;
    GameObject openMouthFrames;
    bool lineIsDone;
    string vowels = "aeiouyAEIOUY";
    string[] lines;

    DialogueController dialogueController;
    GameStats gameStats;

    private void Awake() 
    {
        gameStats = FindObjectOfType<GameStats>();
    }

    private void Start() 
    {
        ClearTextAtStart();
    }

    private void ClearTextAtStart() 
    {
        textBox.gameObject.SetActive(true);
        textBox.CrossFadeColor(new Color(0, 0, 0, 0), 0, false, true);
        charName.text = "";
        charText.text = "";
    }

    public void ClearText() 
    {
        textBox.CrossFadeColor(new Color(0, 0, 0, 0), textBoxFadeSpeed, false, true);
        charName.text = "";
        charText.text = "";
        dialogueController.SetBoxColliderSizeToDefault();
        gameStats.SetCanClick();
    }

    public void SetName(string cn) 
    {
        charName.text = cn;
        textBox.CrossFadeColor(textBoxColor, textBoxFadeSpeed, false, true);
        GameObject charObj = GameObject.Find(cn).gameObject;
        dialogueController = charObj.GetComponent<DialogueController>();
    }

    public string GetName()
    {
        return charName.text;
    }

    public void SpeedUpText() 
    {
        textSpeed = 0f;
    }

    public IEnumerator SpeakLine(string line) 
    {
        textSpeed = standardTextSpeed;
        charText.text = "";
        dialogueController.SetIsSpeakingLine(true);

        for (int i = 0; i < line.Length; i++)
        {
            char lineChar = line[i];
            charText.text += lineChar;

            if (vowels.Contains(lineChar))
            {
                dialogueController.SetMouthAnimation(true);
            }
            else
            {
                dialogueController.SetMouthAnimation(false);
            }

            yield return new WaitForSeconds(textSpeed);
        }

        dialogueController.SetIsSpeakingLine(false);
    }
}
