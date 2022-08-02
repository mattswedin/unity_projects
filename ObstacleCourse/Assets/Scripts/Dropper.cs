using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
   void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            GetComponentInParent<Rigidbody>().useGravity = true;
        }
        
   }
}
