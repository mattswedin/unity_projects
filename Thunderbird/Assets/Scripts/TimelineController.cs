using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector pd;
    [SerializeField] bool isLevel;
    [SerializeField] float speed = 2f;
    [SerializeField] float timelineBreakpoint = 90f;

    LevelStats levelStats;
    PlayerController playerController;


    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
        levelStats = FindObjectOfType<LevelStats>();
        pd = GetComponent<PlayableDirector>();
    }

    void Start() 
    {
       pd.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    public void Play() 
    {
        pd.Play();
    }

    public float GetTimelineBreakpoint()
    {
        return timelineBreakpoint;
    }
}
