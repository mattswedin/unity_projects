using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    bool facingRight = true;

   void OnCollisionEnter(Collision other) 
   {

        if (other.gameObject.tag != "Ground")
        {
            if (transform.rotation.y == 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                facingRight = false;
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                facingRight = true;
            }
        }
 
   }

    void Update()
    {
        if (facingRight)
        {
            transform.Translate(transform.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(-transform.right * Time.deltaTime * speed);
        }
        
    }
}
