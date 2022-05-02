using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public bool GameEnd = false;
    GameObject levelSpeed;
    SurfaceEffector2D levelSpeedComp;
    [SerializeField] float slowMoFinish = 1f;
    [SerializeField] float reloadSceneDelayTime = 2f;
    [SerializeField] ParticleSystem finishEffect;
    void Start() {
        levelSpeed = GameObject.Find("Level Sprite Shape");
        levelSpeedComp = levelSpeed.GetComponent<SurfaceEffector2D>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            levelSpeedComp.speed = slowMoFinish;
            finishEffect.Play();
            Invoke("ReloadScene", reloadSceneDelayTime);
            GameEnd = true;
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
