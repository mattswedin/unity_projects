using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingShooterController : MonoBehaviour
{
    [SerializeField] GameObject ring;
    [SerializeField] float timeBetweenRings = 1f;
    [SerializeField] bool isShooting;
    [SerializeField] bool canShootAgain = true;

    void Update()
    {
        if (canShootAgain) StartCoroutine(RingShoot());
    }

    IEnumerator RingShoot()
    {
        
        GameObject ringInstance = Instantiate(ring, transform.position, Quaternion.identity);
        canShootAgain = false;
        yield return new WaitForSeconds(timeBetweenRings);
        canShootAgain = true;
        
    }
}
