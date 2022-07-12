using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    // [SerializeField] float bossTime = 3f;

    [SerializeField] bool isLooping = true;
    bool isBossTime = false;
    public bool bossDefeated = false;
    [SerializeField] WaveConfigSO bossWave;
    WaveConfigSO currentWave;
    ScoreKeeper scorekeeper;
    float startingScore;

    void Awake() 
    {
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }
    

    void Start()
    {
        startingScore = scorekeeper.GetCurrentScore();
        StartCoroutine(SpawnEnemyWaves());
    }

    void Update() {

        if (bossDefeated)
        {
            Debug.Log("Beat Boss");
            isBossTime = false;
            bossDefeated = false;
            startingScore = scorekeeper.GetCurrentScore();
            StartCoroutine(SpawnEnemyWaves());
            
        }

        if (scorekeeper.GetCurrentScore() >= (startingScore + 500f))
        {
            Debug.Log("BOSS TIME");
            isBossTime = true;
            startingScore = scorekeeper.GetCurrentScore();

        }
    }

    public WaveConfigSO GetCurrentWave() 
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves() 
    {
        do {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                if(isBossTime)
                {
                    currentWave = bossWave;
                    break;
                    
                }

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
        while (isLooping && !isBossTime);

        Instantiate(bossWave.GetEnemyPrefab(0),
            currentWave.GetStartingWaypoint().position,
            Quaternion.identity,
            transform);

       
    }


}
