using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool isFlying;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform[] wayPoints;
    int i = 0;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        Move();
    }

    void Move() 
    {
        if (i < wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    wayPoints[i].position,
                                                    speed * Time.deltaTime);
            if (transform.position == wayPoints[i].position)
            {
                i++;
            }

            if (i == wayPoints.Length)
            {
                i = 0;
            }
        }
    }
    
}
