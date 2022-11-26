using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRangeTop = 10f;
    [SerializeField] float yRangeBottom = -3f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationSpeed = 5f;

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
        if(IsMoving())
        {

            float xClamp = UnityEngine.Mathf.Clamp(transform.localPosition.x + moveInput.x * moveSpeed * Time.deltaTime, -xRange, xRange);
            float yClamp = UnityEngine.Mathf.Clamp(transform.localPosition.y +  moveInput.y * moveSpeed * Time.deltaTime, yRangeBottom, yRangeTop);
            Vector3 movement = new Vector3(xClamp, yClamp, 0);
            transform.localPosition = new Vector3(movement.x, movement.y, transform.localPosition.z);
        }
    }

    bool IsMoving()
    {
        if (moveInput.x > 0 || moveInput.x < 0 || moveInput.y > 0 || moveInput.y < 0)
        {
            return true;
        }
        return false;
    }
}
