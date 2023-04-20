using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    GameObject thunderBirdObj;
    Vector3 thunderBirdpos;
    [SerializeField] float speed = 200f;
    [SerializeField] Vector3 projectilePos;
    bool continueing = false;

    void Awake()
    {
        thunderBirdObj = GameObject.Find("ThunderBirdRig");
        thunderBirdpos = thunderBirdObj.transform.GetChild(1).gameObject.transform.position;
        thunderBirdpos.y += 4f;

    }


    void Update()
    {
        
        if (continueing) 
        {
            ShootStraight();
        }
        else
        {
            Shoot();
        }

    }

    void ShootStraight()
    {
        transform.Translate(Vector3.down * 7, Space.Self);
    }

    void Shoot() 
    {
        if (speed > 1) speed -= .5f;
        transform.position = Vector3.MoveTowards(transform.position, thunderBirdpos, speed * Time.deltaTime);

        if (transform.position == thunderBirdpos)
        {
            StartCoroutine(Continue());
        }
    }

    IEnumerator Continue() 
    {
        continueing = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }



}
