using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScoreDisplay : MonoBehaviour
{
    Rigidbody rb;
    UIDisplay uIDisplay;
    [SerializeField] float spinSpeed = 5f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start() 
    {
        
    }

    void Update()
    {
        rb.AddTorque(Vector3.up * spinSpeed);
    }
}
