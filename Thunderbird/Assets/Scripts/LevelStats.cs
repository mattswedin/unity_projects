using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] Dictionary<string, int> enemyGroups = new Dictionary<string, int>();
    
    void Start() 
    {
        LoadEnemyGroups();
    }

    void LoadEnemyGroups() 
    {
        GameObject enemies = GameObject.Find("Enemies");
        foreach (GameObject child in enemies.transform)
        {
            enemyGroups[child.name] = child.transform.childCount;
        }
    }
}
