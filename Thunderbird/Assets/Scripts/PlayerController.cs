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
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -10f;

    void Update()
    {
        Fly();
        FlyRotation();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Fly() 
    {
        if(IsMoving())
        {
            float xClamp = UnityEngine.Mathf.Clamp(transform.localPosition.x 
                                                    + moveInput.x * moveSpeed * Time.deltaTime, -xRange, xRange);
            float yClamp = UnityEngine.Mathf.Clamp(transform.localPosition.y 
                                                    + moveInput.y * moveSpeed * Time.deltaTime, yRangeBottom, yRangeTop);
            Vector3 movement = new Vector3(xClamp, yClamp, 0);
            transform.localPosition = new Vector3(movement.x, movement.y, transform.localPosition.z);
        }
    }

    void FlyRotation() 
    {
        if (IsMoving())
        {
            float pitch = transform.localPosition.y * positionPitchFactor + moveInput.y * controlPitchFactor;
            float yaw = 0f;
            float roll = 0f;
            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
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
