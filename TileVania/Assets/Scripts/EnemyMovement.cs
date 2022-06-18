using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        FLipEnemyFacing();
    }

    void FLipEnemyFacing()
    {
        if (transform.localRotation.y == 0f)
        {
            transform.localRotation = new Quaternion(transform.localRotation.x, 180f, 0f, 0f);
        }
        else
        {
            transform.localRotation = new Quaternion(transform.localRotation.x, 0f, 0f, 0f);
        }
        
    }
}
