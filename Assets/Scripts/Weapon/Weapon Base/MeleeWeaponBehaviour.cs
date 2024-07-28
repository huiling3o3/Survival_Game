using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
public class MeleeWeaponBehaviour : MonoBehaviour
{
    protected WeaponController wc;
    public virtual void init(WeaponController wc)
    {
        this.wc = wc;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
        {
            if (col.CompareTag("Enemy"))
            {
                EnemyController enemy = col.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(wc.GetWeaponDamage());
                }
            }
            else if (col.CompareTag("Barrel"))
            {
                BarrelController barrel = col.GetComponent<BarrelController>();
                if (barrel != null)
                {
                    barrel.TakeHit();
                }
                
            }
        }
        
    }

}
