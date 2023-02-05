using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector pd;
    [SerializeField] bool isLevel;
    [SerializeField] float speed = 2f;


    void Awake() 
    {
        pd = GetComponent<PlayableDirector>();
    }

    void Start() 
    {
        pd.playableGraph.GetRootPlayable(0).SetSpeed(speed);
        
    }

    void Update() 
    {
        if (isLevel && pd.playableGraph.IsDone())
        {
            Debug.Log("Done");
        }
    }
}
