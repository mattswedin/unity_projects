using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody rb;
    [SerializeField] float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Fly();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Fly() 
    {
        Vector3 playerVelocity = new Vector3(moveInput.x, moveInput.y, 0.0f);
        rb.velocity = transform.TransformDirection(playerVelocity * speed);
    }
}
