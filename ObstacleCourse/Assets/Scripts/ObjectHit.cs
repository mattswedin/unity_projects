using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) 
   {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
   }
}
