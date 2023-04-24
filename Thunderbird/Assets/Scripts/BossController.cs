using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] int health = 1000;

    [Header("Boss Timing")]
    [SerializeField] float startDelay = 1.5f;
    [SerializeField] bool canShoot = true;

    [Header("Boss Objects")]
    [SerializeField] GameObject[] bossPhases;
    [SerializeField] int bossIndex;

    

    GameObject currentBossPhase;

    void Start() 
    {
        StartCoroutine(BossBegins());
    }

    IEnumerator BossBegins() 
    {
        yield return new WaitForSeconds(startDelay);
        currentBossPhase = bossPhases[bossIndex];
        currentBossPhase.SetActive(true);
    }

    public IEnumerator EndBossPhase() 
    {
        yield return new WaitForSeconds(startDelay);
        Destroy(bossPhases[bossIndex]);
        bossIndex++;
        currentBossPhase = bossPhases[bossIndex];
        currentBossPhase.SetActive(true);
    }

    public void CanBossShoot(bool state) 
    {
        currentBossPhase.GetComponent<Enemy>().CanBossShoot(state);
    }



}
