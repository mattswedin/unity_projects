using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForce = 10f;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }

    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.RightArrow) ||
                 Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.left);
        }
    }
}
