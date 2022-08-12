using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForce = 10f;
    [SerializeField] float rotateThrustForce = 1f;
    [SerializeField] AudioSource rocketSFX;

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
            if (!rocketSFX.isPlaying)
            {
                rocketSFX.Play();
            }
        }
        else
        {
            rocketSFX.Pause();
        }

    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) ||
                 Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.left);
        }
    }

    void ApplyRotation(Vector3 direction) 
    {
        transform.Rotate(direction * rotateThrustForce * Time.deltaTime);
    }
}
