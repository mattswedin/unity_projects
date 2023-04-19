using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    GameObject thunderBirdObj;
    Vector3 thunderBirdpos;
    [SerializeField] float speed = 200f;

    void Awake()
    {
        thunderBirdObj = GameObject.Find("ThunderBirdRig");
        thunderBirdpos = thunderBirdObj.transform.GetChild(1).gameObject.transform.position;
        // thunderBirdpos.z += -15;

    }

    void Update()
    {
        Shoot();
    }

    void ShootStraight()
    {
        transform.Translate(Vector3.down * 5, Space.Self);
    }

    void Shoot() 
    {
        if (speed > 1) speed -= .5f;
        transform.position = Vector3.MoveTowards(transform.position, thunderBirdpos, speed * Time.deltaTime);

        if (transform.position == thunderBirdpos)
        {
            Destroy(gameObject);
        }
    }

}
