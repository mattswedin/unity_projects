using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  string frogParentName;

  Player player;
  UIDisplay uIDisplay;
  SceneSwitcher sceneSwitcher;
  PlayerStats playerStats;

  void Awake() 
  {
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
            playerStats.SetFrogCountCurrentLevel(uIDisplay.GetFinishFrogPoints(), 
                                                sceneSwitcher.GetCurrentLevelName());
            sceneSwitcher.LoadFrogScoreScene();
            break;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    switch (other.tag)
    {
      case "Frog":
        if (other.gameObject.transform.parent.name != frogParentName) 
        {
          frogParentName = other.gameObject.transform.parent.name;
          Destroy(other.gameObject.transform.parent.gameObject);
          uIDisplay.AddFrogPoint();
        }
        
        
        break;
    }
  }
}


