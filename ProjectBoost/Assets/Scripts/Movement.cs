using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed Space");
        }

    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow) ||
                 Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed Right");
        }
    }
}
