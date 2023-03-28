using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] float time = 1f;
    
    void Start()
    {
        StartCoroutine(DestroyTimed());
    }

    IEnumerator DestroyTimed()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
