using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MultiTimelineManager : MonoBehaviour
{
    [SerializeField] GameObject[] timelines;
    [SerializeField] int timelineIndex = 0;

    void Update() 
    {
        TimelineManagment();
    }

    private void TimelineManagment()
    {
        if (timelines.Length > 0)
        {
            timelines[timelineIndex].GetComponent<TimelineController>().Play();

            if (!timelines[timelineIndex]) timelineIndex++;
        }
    }
}