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
    [SerializeField] GameObject bossPhaseOne;
    [SerializeField] GameObject bossPhaseTwo;

    

    GameObject currentBossPhase;

    void Start() 
    {
        StartCoroutine(BossBegins());
    }

    IEnumerator BossBegins() 
    {
        yield return new WaitForSeconds(startDelay);
        bossPhaseOne.SetActive(true);
        currentBossPhase = bossPhaseOne;

    }

    public IEnumerator EndBossPhaseOne() 
    {
        yield return new WaitForSeconds(startDelay);
        bossPhaseTwo.SetActive(true);
        currentBossPhase = bossPhaseTwo;
        Destroy(bossPhaseOne);
    }

    public void CanBossShoot(bool state) 
    {
        currentBossPhase.GetComponent<Enemy>().CanBossShoot(state);
    }



}
