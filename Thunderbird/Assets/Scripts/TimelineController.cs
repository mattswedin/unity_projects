using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector pd;
    [SerializeField] bool isLevel;
    [SerializeField] float speed = 2f;
    [SerializeField] float eventTime = 90f;
    [SerializeField] Camera[] cutSceneCameras;
    Camera currentCamera;

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
       currentCamera = Camera.current;
       pd.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    void Update() 
    {
        if (pd.playableGraph.GetRootPlayable(0).GetTime() == eventTime)
        {
            playerController.SetCantMove(true);
            ChangeCamera(0);
        };
    }

    void ChangeCamera(int idx)
    {
        currentCamera.enabled = false;
        cutSceneCameras[idx].enabled = true;
        currentCamera = cutSceneCameras[idx];
    }
}
