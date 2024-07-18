using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    public override void init(WeaponController wc)
    {
        base.init(wc);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(wc.damage);
        }
        else if (col.CompareTag("Barrel"))
        {
            BarrelController barrel = col.GetComponent<BarrelController>();
            barrel.TakeHit();
        }
    }

}
