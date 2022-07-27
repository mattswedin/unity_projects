using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] float timeUntilBoss = 2f;
    [SerializeField] WaveConfigSO bossWave;
    [SerializeField] List<WaveConfigSO> finalBossWave;

    public bool bossDefeated = false;

    WaveConfigSO currentWave;
    LevelManager levelManager;

    void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    
    void Start()
    {
        if (finalBossWave.Count == 0)
        {
            StartCoroutine(SpawnEnemyWaves());
        }
        else
        {
            StartCoroutine(SpawnFinalBossWaves());
        }
    }

    void Update() 
    {
        if (bossDefeated)
        {
            levelManager.LoadNextLevel();
        }
    }

    public WaveConfigSO GetCurrentWave() 
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves() 
    {    
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        currentWave = bossWave;
        
        yield return new WaitForSeconds(timeUntilBoss);
        Instantiate(bossWave.GetEnemyPrefab(0),
            currentWave.GetStartingWaypoint().position,
            Quaternion.identity,
            transform);
       
    }

    IEnumerator SpawnFinalBossWaves()
    {
        yield return new WaitForSeconds(timeUntilBoss);
        foreach (WaveConfigSO bossWave in finalBossWave)
        {
            currentWave = bossWave;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
