using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool isWheel;
    [SerializeField] float spinSpeed = 20f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (isWheel)
        {
            rb.AddTorque(new Vector3(0,0,1 * spinSpeed));
        }
        else
        {
            rb.AddTorque(Vector3.up * spinSpeed);
        }
        
    }
}
