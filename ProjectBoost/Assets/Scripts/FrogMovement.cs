using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [Header("Frog")]
    [SerializeField] float minTimeBetweenJumps = .1f;
    [SerializeField] float maxTimeBetweenJumps = 1f;
    [SerializeField] float jumpHeight = 15f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJumpAgain = false;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip ribbet;
    [Header("Moving Frog")]
    [SerializeField] bool isMoving;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] Transform[] rotation;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float extraHeight = 2.5f;
    [Header("Score Frog")]
    [SerializeField] bool isScoreFrogRunning;
    [SerializeField] bool isScoreFrogEndPosition;
    [SerializeField] float spinSpeed = 5f;
    int i = 0;
    int j = 0;

    Rigidbody rb;
    AudioSource audioSource;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (!isScoreFrogRunning && !isScoreFrogEndPosition)
        {
            FrogJump();
            if(isMoving)
            {
                Move();
            }
        }
        else if (isScoreFrogRunning)
        {
            rb.AddTorque(Vector3.up * spinSpeed);
        }
        
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

    void Move()
    {
        if (i < wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                    wayPoints[i].position,
                                                    speed * Time.deltaTime);
            if (transform.position == wayPoints[i].position)
            {
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                    rotation[j].rotation,
                                                    rotationSpeed * Time.deltaTime);
                
                if (transform.rotation == rotation[j].rotation)
                {
                    rb.AddForce(Vector3.up * jumpHeight * extraHeight, ForceMode.Impulse);
                    j++;
                    i++;
                    
                    if (j == rotation.Length)
                    {
                        j = 0;
                    }
                }
            }

            if (i == wayPoints.Length)
            {
                i = 0;
            }
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
