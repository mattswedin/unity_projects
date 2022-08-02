using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    Hashtable hashtable = new Hashtable(0);

    void OnCollisionEnter(Collision other) 
    {
        string bumpedObject = other.gameObject.name;

        if(hashtable[bumpedObject] == null)
        {
            hashtable[bumpedObject] = 1;
        }
        else
        {
            int bumpedValue = (int) hashtable[bumpedObject];
            hashtable[bumpedObject] = bumpedValue + 1;
        }

        Debug.Log("You have hit " + bumpedObject + " " + hashtable[bumpedObject] + " times.");
    }
}
