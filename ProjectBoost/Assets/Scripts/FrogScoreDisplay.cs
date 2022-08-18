using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrogScoreDisplay : MonoBehaviour
{
    PlayerStats playerStats;
    SceneSwitcher sceneSwitcher;

    [SerializeField] float timeBetweenScoreFrogs = 1f;
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] TextMeshProUGUI remainingLife;
    string lifeAmountDisplay;
    [SerializeField] TextMeshProUGUI frogMessage;
    [SerializeField] GameObject scoreFrogWin;
    [SerializeField] GameObject scoreFrogLose;

    bool scoreFrogDisplayHasEnded = false;

    void Awake() 
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start() 
    {
        StartCoroutine(SetScoreFrogDisplay());
    }

    void Update() 
    {
        if (scoreFrogDisplayHasEnded)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                sceneSwitcher.LoadNextLevel();
            }
        }
    }

    IEnumerator SetScoreFrogDisplay()
    {
        string previousLevel = playerStats.GetLastLevelCompleted();
        int currentLevelTotal = playerStats.GetFrogCurrentLevelTotal(previousLevel);
        int currentLevelSaved = playerStats.GetFrogCountCurrentLevel(previousLevel);
        GameObject specificFrogRow = GameObject.Find(currentLevelTotal.ToString());

        yield return new WaitForSeconds(timeBetweenScoreFrogs);

        levelName.text = previousLevel + " Completed";

        yield return new WaitForSeconds(timeBetweenScoreFrogs);

        for (int i = 0; i < playerStats.GetHealth(); i++)
        {
            lifeAmountDisplay += "(";
        }

        remainingLife.text = "Life: " + lifeAmountDisplay;

        yield return new WaitForSeconds(timeBetweenScoreFrogs);

        for(int i = 0; i < currentLevelSaved; i++)
        {
            specificFrogRow.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(timeBetweenScoreFrogs);
        }

        for(int i = 0; i <currentLevelSaved; i++)
        {
            Vector3 frogPos = specificFrogRow.transform.GetChild(i).gameObject.transform.position;   
            specificFrogRow.transform.GetChild(i).gameObject.SetActive(false);
            Instantiate
            (
                currentLevelSaved != currentLevelTotal ? scoreFrogLose : scoreFrogWin,
                currentLevelSaved != currentLevelTotal ? new Vector3(frogPos.x, frogPos.y + .3f, frogPos.z) : new Vector3(frogPos.x, frogPos.y + 1.9f, frogPos.z),
                currentLevelSaved != currentLevelTotal ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, 90, 0, 90),
                specificFrogRow.transform
            );
        }

        yield return new WaitForSeconds(timeBetweenScoreFrogs);

        if(currentLevelSaved != currentLevelTotal)
        {
            frogMessage.text = "Save More Frogs";
        } 
        else
        {
            frogMessage.text = "All Frogs Saved";
            remainingLife.text += "(";
            playerStats.GainLife();

        }

        yield return new WaitForSeconds(timeBetweenScoreFrogs);

        scoreFrogDisplayHasEnded = true;

    }
}
