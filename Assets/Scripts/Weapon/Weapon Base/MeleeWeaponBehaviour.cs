using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;
    protected WeaponController wc;
    public virtual void init(WeaponController wc)
    {
        Destroy(gameObject, destroyAfterSeconds);
        this.wc = wc;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(wc.damage);
        }
    }

}
