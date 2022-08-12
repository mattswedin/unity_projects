using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  UIDisplay uIDisplay;

  void Awake() {
    uIDisplay = FindObjectOfType<UIDisplay>();
  }
 
  void OnCollisionEnter(Collision other) 
  {
    switch (other.gameObject.tag)
    {
        case "Enemy":
            Debug.Log("I am an Enemy!");
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
        Destroy(other.gameObject.transform.parent.gameObject);
        uIDisplay.AddFrogPoint();
        break;
    }
  }
}


