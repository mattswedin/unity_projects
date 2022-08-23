using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  string frogParentName;
  [SerializeField] List<AudioClip> robotBump;
  [SerializeField] AudioClip losLifeExplos;
  [SerializeField] [Range(0, 5f)] float loseLifeExplosVolume;
  [SerializeField] AudioSource audioSourceSFX;

  Player player;
  UIDisplay uIDisplay;
  SceneSwitcher sceneSwitcher;
  PlayerStats playerStats;
  FrogMovement frogMovement;
  AudioPlayer audioPlayer;

  void Awake() 
  {
    audioPlayer = FindObjectOfType<AudioPlayer>();
    playerStats = FindObjectOfType<PlayerStats>();
    sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    uIDisplay = FindObjectOfType<UIDisplay>();
    player = FindObjectOfType<Player>();
  }
 
  void OnCollisionEnter(Collision other) 
  {

    switch (other.gameObject.tag)
    {
        case "Enemy":
            StartCoroutine(player.LoseLife());
            break;
        case "Finish":
            StartCoroutine(player.DissapearAtFinish());
            playerStats.SetFrogCountCurrentLevel(uIDisplay.GetFinishFrogPoints(), 
                                                sceneSwitcher.GetCurrentLevelName());
            StartCoroutine(sceneSwitcher.LoadFrogScoreScene());
            break;
        case "Ground":
          break;

        default:
            int rando = new System.Random().Next(0, robotBump.Count);
            audioSourceSFX.PlayOneShot(robotBump[rando]);
            break;
    }
  }

  public void PlayExplosion() 
  {
        audioSourceSFX.PlayOneShot(losLifeExplos, loseLifeExplosVolume);
  }

  void OnTriggerEnter(Collider other)
  {
    var parent = other.gameObject.transform.parent;
    switch (other.tag)
    {
      
      case "Frog":
        if (parent.name != frogParentName) 
        {
          frogParentName = parent.name;
          audioPlayer.PlayRandomRibbet();
          Destroy(parent.gameObject);
          uIDisplay.AddFrogPoint();
        }
        
        
        break;
    }
  }
}


