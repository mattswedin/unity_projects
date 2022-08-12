using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
 
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

        break;
    }
  }
}


