using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charName;
    [SerializeField] TextMeshProUGUI charText;
    [SerializeField] float standardCharSpeed = .1f;
    GameObject openMouthFrames;
    bool lineIsDone;
    string vowels = "aeiouAEIOU";
    string[] lines;

    public void Start() 
    {
        ClearText();
    }

    public void ClearText() 
    {
        charName.text = "";
        charText.text = "";
    }

    public void SetName(string cn) 
    {
        charName.text = cn;
    }

    public string GetName()
    {
        return charName.text;
    }

    public IEnumerator SpeakLine(string line) 
    {
        charText.text = "";

        for (int i = 0; i < line.Length; i++)
        {
            char lineChar = line[i];
            charText.text += lineChar;

            if (vowels.Contains(lineChar))
            {
                // openMouthCharacter = character.transform.GetChild(0).gameObject;
                // openMouthCharacter.GetComponent<SpriteRenderer>().color;
            }

            yield return new WaitForSeconds(standardCharSpeed);
        }
    }
}
