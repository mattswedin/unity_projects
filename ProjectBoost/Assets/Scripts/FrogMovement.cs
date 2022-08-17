using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] float minTimeBetweenJumps = .1f;
    [SerializeField] float maxTimeBetweenJumps = 1f;
    [SerializeField] float jumpHeight = 15f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJumpAgain = false;
    [SerializeField] AudioClip jumpSFX;
    Rigidbody rb;
    AudioSource audioSource;
    


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FrogJump();
    }

    void FrogJump()
    {
        if (!isJumping && canJumpAgain)
        {
            audioSource.PlayOneShot(jumpSFX, .5f);
            canJumpAgain = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
            StartCoroutine(WaitRandomSeconds());
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }

    IEnumerator WaitRandomSeconds()
    {
        float timeBetweenJumps = Random.Range(minTimeBetweenJumps, maxTimeBetweenJumps);
        yield return new WaitForSeconds(timeBetweenJumps);
        canJumpAgain = true;
        
    }
}
