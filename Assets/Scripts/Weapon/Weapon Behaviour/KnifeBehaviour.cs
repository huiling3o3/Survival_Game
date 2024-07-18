using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    // Start is called before the first frame update
    //public override void init(WeaponController wc)
    //{
    //    base.init();
    //    this.wc = wc;
    //}

    // Update is called once per frame
    protected void Update()
    {
        //set the movement of the knife
        transform.position += direction * wc.speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        //Reference the script from the collided collider and deal damage using TakeDamage()
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(wc.damage);
            Destroy(gameObject);
        }
    }
}
