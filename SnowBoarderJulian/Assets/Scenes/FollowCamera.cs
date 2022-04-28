using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    void Update()
    {
        transform.position = Ball.transform.position + new Vector3 (0, 0, -2);
    }
}
