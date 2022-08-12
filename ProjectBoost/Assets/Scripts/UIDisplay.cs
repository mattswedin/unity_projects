using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI life;
    [SerializeField] TextMeshProUGUI frogCount;
    Player player;

    void Awake() 
    {
        player = FindObjectOfType<Player>();
    }
    
    void Start()
    {
        frogCount.text = "Frogs: 0";
        SetUpLife();
    }

    void SetUpLife ()
    {
        for(int i = 0; i < player.GetHealth(); i++)
        {
            life.text += "(";
        }
    }

    public void AddFrogPoint() 
    {
        int currentFrogAmount = Int32.Parse(frogCount.text.Split(" ")[1]);
        currentFrogAmount += 1;
        frogCount.text = "Frogs: " + currentFrogAmount;
    }
}
