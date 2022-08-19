using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float spinSpeed = 20f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.AddTorque(Vector3.up * spinSpeed);
    }
}
