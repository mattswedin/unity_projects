using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Vector3 positionOffset = new Vector3(0f, 2f, 0f);
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    // [SerializeField] float fireRate = .2f;
    Coroutine firingCoroutine;

    public bool isFiring;

    void FixedUpdate()
    {
        Fire();
    }

    void Fire() 
    {
        if (isFiring)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position + positionOffset, Quaternion.identity);
           
            Destroy(instance, projectileLifetime);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
                
            }
            isFiring = false;

        }
         
    }
   
    

    
}
