using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLightningShooter : MonoBehaviour
{
    [SerializeField] float timeBetweenLightning = 1;
    [SerializeField] float preLightingTime = 1;
    [SerializeField] int lightningCount = 4;
    [SerializeField] GameObject preLightning;
    [SerializeField] GameObject lightning;
    GameObject lightningInstance;
    GameObject prelightningInstance;
    Vector3 playerPos;

    PlayerController playerController;

    void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        StartCoroutine(ShootLighting());
    }

    IEnumerator ShootLighting() 
    {
        for (int i = 0; i < lightningCount; i++)
        {   
            
            playerPos = playerController.GetCurrentPos();
            prelightningInstance = Instantiate(preLightning, playerPos, transform.rotation);
            yield return new WaitForSeconds(preLightingTime);

            playerPos.y += 50;
            lightningInstance = Instantiate(lightning, playerPos, transform.rotation);
            yield return new WaitForSeconds(timeBetweenLightning);
            Destroy(prelightningInstance);
        }
        
    }
}
