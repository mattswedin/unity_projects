using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  string frogParentName;
  bool invincibilityframes = false;

  Player player;
  UIDisplay uIDisplay;

  void Awake() 
  {
    uIDisplay = FindObjectOfType<UIDisplay>();
    player = FindObjectOfType<Player>();
  }
 
  void OnCollisionEnter(Collision other) 
  {
    switch (other.gameObject.tag)
    {
        case "Enemy":
            player.LoseLife();
            break;
        case "Finish":
            SceneManager.LoadScene(0);
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


