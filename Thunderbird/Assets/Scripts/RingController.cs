using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    [SerializeField] Transform startingPos;
    [SerializeField] Transform endingPos;
    [SerializeField] float speed = 100f;
    
    void Update()
    {
        RingShoot();
    }

    void RingShoot()
    {
        transform.position = Vector3.MoveTowards(transform.position, endingPos.position, speed * Time.deltaTime);

        if (transform.position == endingPos.position)
        {
            Destroy(gameObject);
        }
    }
}
