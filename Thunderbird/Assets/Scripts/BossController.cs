using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] int health = 1000;

    [Header("Boss Coordinates")]
    [SerializeField] Vector3 startingPos;

    [Header("Boss Timing")]
    [SerializeField] float startDelay = 1.5f;


    IEnumerator BossPhaseOne() 
    {
        yield return new WaitForSeconds(startDelay);

    }

}
