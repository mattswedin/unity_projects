using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dieDelay = 2f;
   void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.tag == "Ground")
       {
            Invoke("diedRestartLevel", dieDelay);
       }
       
   }

   void diedRestartLevel()
   {
        Debug.Log("Ouch my head");
        SceneManager.LoadScene(0);
   }
}
