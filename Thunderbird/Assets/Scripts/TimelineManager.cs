using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] GameObject currentTimeline;
    [SerializeField] GameObject[] timelines;
    [SerializeField] int timelineIndex;
    

    void Start()
    {
        currentTimeline = timelines[timelineIndex];
        currentTimeline.SetActive(true);
    }

    public void EndCurrentTimeline()
    {
        timelineIndex++;

        if (timelineIndex < timelines.Length)
        {
            currentTimeline = timelines[timelineIndex];
            timelines[timelineIndex - 1].SetActive(false);
            currentTimeline.SetActive(true);
            Destroy(timelines[timelineIndex - 1]);
        }
        else
        {
            Debug.Log("Done");
        }
    }
}
