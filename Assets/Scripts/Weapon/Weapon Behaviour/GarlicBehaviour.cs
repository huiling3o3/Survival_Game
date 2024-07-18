using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;
    public override void init(WeaponController wc)
    {
        base.init(wc);
        //markedEnemies = new List<GameObject>();
        //gc = FindAnyObjectByType<GarlicController>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(wc.damage);
        }
    }

}
