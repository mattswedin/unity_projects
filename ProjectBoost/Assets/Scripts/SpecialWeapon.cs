using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    [SerializeField] float weaponPower = 0;

    public float GetWeaponPower()
    {
        return weaponPower;
    }

}
