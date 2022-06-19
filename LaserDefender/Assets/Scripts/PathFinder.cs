using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        
    }
}
