using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dieDelay = 2f;
    [SerializeField] ParticleSystem bloodEffect;
    [SerializeField] ParticleSystem dustTrail;
    bool dead = false;



    void OnCollisionEnter2D(Collision2D other)
    {
        if (!dead)
        {
            dustTrail.Play();
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        dustTrail.Stop();
    }
   void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.tag == "Ground")
       {
           dead = true;
           dustTrail.Stop();
           bloodEffect.Play();
           Invoke("diedRestartLevel", dieDelay);
       }
       
   }

   void diedRestartLevel()
   {
        Debug.Log("Ouch my head");
        SceneManager.LoadScene(0);
   }
}
