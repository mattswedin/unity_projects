using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float attackPower = .5f;
    [SerializeField] bool isLightning;
    CapsuleCollider capsuleCollider;


    void Awake() 
    {
        if (isLightning) capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Start() 
    {
        if (isLightning)
        {
            capsuleCollider.enabled = false;
            StartCoroutine(ActivateLightningCollider());
        } 
    }

    IEnumerator ActivateLightningCollider()
    {
        yield return new WaitForSeconds(.2f);
        capsuleCollider.enabled = true;
        Debug.Log("NOW");
        yield return new WaitForSeconds(.3f);
        capsuleCollider.enabled = false;
    }

    public float GetAttackPower() 
    {
        return attackPower;
    }
}
