using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Results : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI levelResult;
    [SerializeField] TextMeshProUGUI resultResult;
    [SerializeField] int numberOfCompleted = 0;
    [SerializeField] float timeBetweenFrogsMin = .0005f;
    [SerializeField] float timeBetweenFrogsMax = .7f;
    [SerializeField] GameObject frog;
    bool frogFallsEnded;
    GameObject rainbow;

    FadeInOut fadeInOut;
    PlayerStats playerStats;
    SceneSwitcher sceneSwitcher;


    void Awake() 
    {
        playerStats = FindObjectOfType<PlayerStats>();
        fadeInOut = FindObjectOfType<FadeInOut>();
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        rainbow = GameObject.Find("AllFrogsSaved");
    }

    void Start()
    {
        if (playerStats.GetFrogTotalCount() == 36)
        {
            rainbow.transform.GetChild(0).gameObject.SetActive(true);
        }
        fadeInOut.FadeOutBlack();
        SetUpResults();
        SetUpDeathsResult();
        StartCoroutine(SetUpFrogsSaved());
    }

    void Update() 
    {
        if (Input.anyKeyDown)
        {
            sceneSwitcher.ToMainMenu();
        }
    }

    void SetUpResults()
    {
        for (int i = 1; i < playerStats.GetLevelsCompleted() + 1; i++)
        {
            int clearTime = Convert.ToInt32(Math.Round(playerStats.GetTimeLevel($"Level {i}")));
            string clearTimeString;

            
            if (clearTime.ToString().Length == 2) 
            {
                if (clearTime >= 60)
                {
                    int remaining = clearTime - 60;

                    if (remaining > 9)
                    {
                        clearTimeString = "1" + ":" + remaining.ToString();
                    }
                    else
                    {
                        clearTimeString = "1" + ":" + "0" + remaining.ToString();
                    }
                }
                else
                {
                    clearTimeString = "0" + ":" + clearTime.ToString();
                }

            }
            else if (clearTime <= 575)
            {
               string num = (clearTime / 60).ToString();
               char wholeNum = num[0];
               int decNum = clearTime % 60;
               if (decNum > 9)
               {
                    clearTimeString = wholeNum + ":" + decNum;
               }
               else
               {
                    clearTimeString = wholeNum + ":0" + decNum;
               }
            }
            else
            {
                clearTimeString = "TIMEOUT";
            }

            if (playerStats.GetFrogCountCurrentLevel($"Level {i}") == 12)
            {
                numberOfCompleted += 1;
            }

            levelResult.text += $"Level {i}   Frogs: {playerStats.GetFrogCountCurrentLevel($"Level {i}")}/12   Time: {clearTimeString}";
            levelResult.text += System.Environment.NewLine;
            levelResult.text += System.Environment.NewLine;
        }
    }

    void SetUpDeathsResult() 
    {
        resultResult.text = $"Deaths: {playerStats.GetDeathCount()}    ";

        if (numberOfCompleted == 3 && playerStats.GetDeathCount() == 0)
        {
            resultResult.text += "YOU ARE TRULY FROG SAVIOR!";
        }
        else if (numberOfCompleted == 3)
        {
            resultResult.text += "EVERY FROG SAVED!";
        }
        else
        {
            resultResult.text += $"FROG DEATHS: {36 - playerStats.GetFrogTotalCount()}";
        }
    }

    IEnumerator SetUpFrogsSaved()
    {
        yield return new WaitForSeconds(timeBetweenFrogsMin);

        if (!frogFallsEnded)
        {
            //add playerStats.GetFrogTotalCount()
            for (int i = 0; i < playerStats.GetFrogTotalCount(); i++)
            {
                int rando = UnityEngine.Random.Range(-11, 1);
                Vector3 pos = new Vector3(-26, rando, 13.7f);
                

                GameObject frogGuy = Instantiate(frog, pos, Quaternion.identity);
                Rigidbody frogGuyRB = frogGuy.GetComponent<Rigidbody>();
                frogGuyRB.AddForce(new Vector3(500,0,0), ForceMode.Impulse);
                frogGuyRB.AddForce(new Vector3(0, 250, 0), ForceMode.Impulse);
                yield return new WaitForSeconds(UnityEngine.Random.Range(timeBetweenFrogsMin, timeBetweenFrogsMax));
            }
            frogFallsEnded = true;
        }
    }
}
