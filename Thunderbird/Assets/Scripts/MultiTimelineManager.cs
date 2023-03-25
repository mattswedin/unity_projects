using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MultiTimelineManager : MonoBehaviour
{
    [SerializeField] GameObject[] timelines;
    [SerializeField] bool timelinePlaying;
    [SerializeField] int timelineIndex = 0;
    TimelineController timelineController;

    private void Start() 
    {
        TimelineManagment();
    }

    void Update() 
    {
        if (timelineController != null) 
        {
            if (timelineController.isDone())
            {
                timelinePlaying = false;
                timelineIndex++;
                TimelineManagment();
            }
            
        }
    }

    private void TimelineManagment()
    {
        if (timelines.Length > 0 && !timelinePlaying)
        {
            timelineController = timelines[timelineIndex].GetComponent<TimelineController>();
            timelineController.Play();
            timelinePlaying = true;
        }
    }
}