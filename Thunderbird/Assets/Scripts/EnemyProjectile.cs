using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float attackPower = .5f;

    public float GetAttackPower() 
    {
        return attackPower;
    }
}
