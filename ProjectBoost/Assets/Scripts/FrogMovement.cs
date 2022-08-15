using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] float timeBetweenJumps = .5f;
    [SerializeField] float jumpHeight = 15f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FrogJump());
    }

    IEnumerator FrogJump()
    {
        while (true)
        {
            rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
            yield return new WaitForSecondsRealtime(timeBetweenJumps);
        }
        
    }
}
