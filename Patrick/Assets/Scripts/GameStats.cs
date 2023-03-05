using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] bool canClick = false;
    [SerializeField] string gameObjName;
    
    public bool GetCanClick(string name) 
    {
        if (canClick && gameObjName == "")
        {
            gameObjName = name;
            canClick = false;
            return true;
        }
        else if (!canClick && name == gameObjName)
        {
            return true;
        }
        else if (!canClick)
        {
            return false;
        }

        return false;
    }

    public void SetCanClick()
    {
        canClick = true;
        gameObjName = "";
    }



    
}
