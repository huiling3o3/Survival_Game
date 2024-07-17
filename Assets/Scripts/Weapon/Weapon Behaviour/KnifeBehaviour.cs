using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    KnifeController kc;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        kc = FindAnyObjectByType<KnifeController>();
    }

    // Update is called once per frame
    protected void Update()
    {
        //set the movement of the knife
        transform.position += direction * kc.speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        //Reference the script from the collided collider and deal damage using TakeDamage()
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(kc.damage);
            Destroy(gameObject);
        }
    }
}
