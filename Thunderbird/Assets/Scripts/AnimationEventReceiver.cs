using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    Enemy enemy;

    private void Awake() {
       enemy = GetComponentInParent<Enemy>();
    }

    public void BossShootReceiver()
    {
        enemy.BossShoot();
    }
}
