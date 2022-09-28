using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float chaseSpeed = .7f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] Transform[] rotation;
    [SerializeField] bool isFlyer;
    [SerializeField] bool isChasing;
    [SerializeField] bool isStatic;
    [SerializeField] bool frogTaken;
    [SerializeField] Material angryEyes;
    [SerializeField] AudioSource chaseAlarm;
    [SerializeField] AudioSource robotScream;
    Material defaultMaterial;

    int i = 0;
    int j = 0;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isStatic)
        {
            if (!isChasing)
            {
                Move();
            }

            if(frogTaken && angryEyes != null)
            {
                ChangeEyes(angryEyes);

            }
        }
    }

    void ChangeEyes(Material material)
    {
        GameObject eyes = this.transform.Find("Eyes").gameObject;
        int childLength = eyes.transform.childCount;
        for (int i = 0; i < childLength; i++)
        {
            GameObject eye = eyes.transform.GetChild(i).gameObject;
            defaultMaterial = eye.GetComponent<MeshRenderer>().material;
            eye.GetComponent<MeshRenderer>().material = material;
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Robot" && frogTaken)
        {
            
            Chase(other.gameObject.transform);
            if (chaseAlarm != null && !chaseAlarm.isPlaying)
            {
                chaseAlarm.Play();
            } 
            isChasing = true;                                            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Robot" && frogTaken)
        {
            if (chaseAlarm != null && chaseAlarm.isPlaying)
            {
                chaseAlarm.Stop();
            }
            isChasing = false;
        }
    }

    void Chase(Transform chased)
    {
    transform.position = Vector3.MoveTowards(transform.position,
                                            chased.position,
                                            chaseSpeed * Time.deltaTime);
    }

    void Move() 
    {
        if (wayPoints.Length != 0 && i < wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    wayPoints[i].position,
                                                    speed * Time.deltaTime);
            if (transform.position == wayPoints[i].position)
            {
                if (!isFlyer)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                    rotation[j].rotation,
                                                    rotationSpeed * Time.deltaTime);
                    if (transform.rotation == rotation[j].rotation)
                    {
                        i++;
                        j++;

                        if (j == rotation.Length)
                        {
                            j = 0;
                        }
                    }
                }
                else
                {
                    i++;
                }        
            }

            if (i == wayPoints.Length)
            {
                i = 0;
            }
        }
    }

    public void setFrogTaken()
    {
        robotScream.Play();
        frogTaken = true;
    }
}
