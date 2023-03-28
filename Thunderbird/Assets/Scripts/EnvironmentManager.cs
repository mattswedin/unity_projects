using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private void OnTriggerExit(Collider other) 
    {
        GameObject obj = other.transform.gameObject;
        Debug.Log(obj.name);
        Destroy(obj);
    }

    private void OnParticleTrigger() 
    {
        
    }

    
}
