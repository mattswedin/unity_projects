using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    string birdsCuredScore = 0
    
    void Start()
    {
        
    }

    void SetBirdsCured()
    {
        birdsCuredScore += 1
    }

    string GetBirdsCured()
    {
        if (birdsCuredScore.ToString().Length == 1)
        {
            return $"0{birdsCuredScore}";
        }
        else
        {
            return birdsCuredScore.ToString();
        }
        
    }
}
