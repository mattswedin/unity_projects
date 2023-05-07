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
    BossController bossController;

    void Awake() 
    {
        bossController = FindObjectOfType<BossController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnEnable()
    {
        StartCoroutine(ShootLighting());
    }

    IEnumerator ShootLighting() 
    {
        for (int i = 0; i < lightningCount; i++)
        {   
            if (bossController.GetHandsDefeated() == 2) yield break; 
            
            playerPos = playerController.GetCurrentPos();
            Instantiate(preLightning, playerPos, transform.rotation);
            yield return new WaitForSeconds(preLightingTime);

            playerPos.y += 50;
            lightningInstance = Instantiate(lightning, playerPos, transform.rotation);
            yield return new WaitForSeconds(timeBetweenLightning);

        }
        
    }
}
