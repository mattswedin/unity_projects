using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    [SerializeField] string levelName;
    // [SerializeField] Dictionary<string, int> enemyGroups = new Dictionary<string, int>();
    // [SerializeField] int enemyGroupsAmount;
    [SerializeField] bool miniBossDefeated;

    GameStats gameStats;

    void Awake() 
    {
        gameStats = FindObjectOfType<GameStats>();
    }
    
    // void Start() 
    // {
    //     // LoadEnemyGroups();
    // }

    // void LoadEnemyGroups() 
    // {
    //     GameObject enemies = GameObject.Find("Enemies");
    //     enemyGroupsAmount = enemies.transform.childCount;

    //     for (int i = 0; i < enemyGroupsAmount; i++)
    //     {
    //         GameObject child = enemies.transform.GetChild(i).gameObject;
    //         enemyGroups[child.name] = child.transform.childCount;
    //     }
    // }

    // public void EnemyDestroyed(string group)
    // {
    //     // enemyGroups[group] -= 1;
    //     // if (enemyGroups[group] == 0) 
    //     // {
    //     //     gameStats.PowerUp();
    //     //     enemyGroupsAmount -= 1;
    //     // }
    // }

    public void MiniBossDestroyed() 
    {
        miniBossDefeated = true;
    }

    //Special
    public bool isSpecialTriggered()
    {
        if (miniBossDefeated) 
        {
            return true;
        }
        return false;
    }
}
