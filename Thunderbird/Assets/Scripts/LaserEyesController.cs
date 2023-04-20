using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyesController : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    void Start() 
    {
        StartCoroutine(DeathDelay());
    }
  
    void Update()
    {
        transform.Translate(Vector3.forward * speed, Space.Self);
    }

    IEnumerator DeathDelay() 
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
