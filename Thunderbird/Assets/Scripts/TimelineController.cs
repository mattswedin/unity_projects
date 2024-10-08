using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector pd;
    [SerializeField] float speed = 2f;

    PlayerController playerController;


    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
        pd = GetComponent<PlayableDirector>();
    }

    void Start() 
    {
       if (pd.playableGraph.IsValid()) 
       {
            pd.playableGraph.GetRootPlayable(0).SetSpeed(speed);
       }
    }

    public void ToggleHold() 
    {
        
    }

    public bool canPlay() 
    {
        return pd != null;
    }

    public bool isDone() 
    {
        if (pd.playableGraph.IsValid())
        {
           return pd.playableGraph.IsDone();
        }
        return false;
    }

    public void Play() 
    {
        pd.Play();
    }
}
