using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] Transform[] rotation;
    [SerializeField] bool isFlyer;
    int i = 0;
    int j = 0;
    
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
                if (!isFlyer)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                    rotation[j].rotation,
                                                    rotationSpeed * Time.deltaTime);
                    if (transform.rotation == rotation[j].rotation)
                    {
                        i++;
                        j++;

                        if (j == rotation.Length)
                        {
                            j = 0;
                        }
                    }
                }
                else
                {
                    i++;
                }        
            }

            if (i == wayPoints.Length)
            {
                i = 0;
            }
        }
    }
}
