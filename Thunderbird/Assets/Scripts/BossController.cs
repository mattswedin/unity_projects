using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] int health = 1000;

    [Header("Boss Timing")]
    [SerializeField] float startDelay = 1.5f;

    [Header("Boss Objects")]
    [SerializeField] GameObject bossPhaseOne;
    [SerializeField] GameObject bossPhaseTwo;

    void Start() 
    {
        StartCoroutine(BossBegins());
    }

    IEnumerator BossBegins() 
    {
        yield return new WaitForSeconds(startDelay);
        bossPhaseOne.SetActive(true);

    }

    public IEnumerator EndBossPhaseOne() 
    {
        yield return new WaitForSeconds(startDelay);
        bossPhaseTwo.SetActive(true);
        Destroy(bossPhaseOne);
    }



}
