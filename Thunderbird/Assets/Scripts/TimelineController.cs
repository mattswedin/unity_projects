using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector pd;
    [SerializeField] bool isLevel;
    [SerializeField] float speed = 2f;

    LevelStats levelStats;


    void Awake() 
    {
        levelStats = FindObjectOfType<LevelStats>();
        pd = GetComponent<PlayableDirector>();
    }

    void Start() 
    {
        pd.playableGraph.GetRootPlayable(0).SetSpeed(speed);
        
    }

    void Update() 
    {
        if (isLevel)
        {
            if (pd.playableGraph.GetRootPlayable(0).GetTime() < 75f
            && levelStats.isSpecialTriggered()) SpecialEnding();
        }
    }

    void SpecialEnding()
    {
        Debug.Log("YES");
        pd.playableGraph.GetRootPlayable(0).Pause();
    }
}
