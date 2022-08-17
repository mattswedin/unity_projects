using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour
{
    Rigidbody rb;
    Quaternion startingRotation;
    Quaternion endRotationPoint = new Quaternion(0,.5f,0,0);
    [SerializeField] float scurrySpeed = 10f;
    [SerializeField] float timeBetweenScurries = 1f;
    [SerializeField] bool isScurrying;
    [SerializeField] float scurryRotation = 5f;
    [SerializeField] bool facingRight = false;
    float startingScale;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        startingRotation = rb.rotation;
        startingScale = transform.localScale.x;
    }

    void Start()
    {
        StartCoroutine(InsectScurry());
    }

    void Update() 
    {
        InsectMovement();
    }

    IEnumerator InsectScurry() 
    {
        while (isScurrying)
        {
            if (rb.rotation.y < startingRotation.y)
            {
                rb.MoveRotation(Quaternion.Euler(0, scurryRotation * Time.deltaTime, 0));
            }
            else
            {
                rb.MoveRotation(Quaternion.Euler(0, -scurryRotation * Time.deltaTime, 0));
            }
            yield return new WaitForSeconds(timeBetweenScurries);
        }

    }

    void InsectMovement() 
    {
        if (facingRight) 
        {
            transform.Translate(Vector3.right * scurrySpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * scurrySpeed * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Ground")
        {  if(transform.localScale.x > 0)
            {
                facingRight = false;
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                                    transform.localScale.y,
                                                    transform.localScale.z);
            }
            else
            {
                facingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), 
                                                transform.localScale.y,
                                                transform.localScale.z);
            } 
        }
    }   
}
