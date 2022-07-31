using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 11f;

    void Start()
    {
        
    }

    void Update()
    {
        float zValue = -Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float xValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(xValue, 0, zValue);
    }
}
