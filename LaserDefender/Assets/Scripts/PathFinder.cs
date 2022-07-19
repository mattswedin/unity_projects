using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] bool isBoss;
    [SerializeField] bool isMouseBoss;
    [SerializeField] float rotateSpeed = 300f;
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() 
    {

        enemySpawner = FindObjectOfType<EnemySpawner>();

    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        if(isBoss)
        {
            FollowBossPath();
        }
        else
        {
            FollowPath();
        }
        
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
           
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FollowBossPath()
    {


        if (!enemySpawner.bossDefeated)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            if (isMouseBoss)
            {   
                Quaternion targetRotation = waypoints[waypointIndex].rotation;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            
            
            if (transform.position == targetPosition)
            {
                if (waypointIndex == (waypoints.Count - 1)) 
                {
                    waypointIndex = 0;
                }
                else
                {
                    waypointIndex++;
                }
                
            }

        }
        
      
    }

    
}
