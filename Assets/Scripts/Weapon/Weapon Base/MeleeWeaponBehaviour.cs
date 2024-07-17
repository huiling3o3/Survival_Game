using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;

    //Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //EnemyStats enemy = col.GetComponent<EnemyStats>();
            //enemy.TakeDamage(currentDamage);
        }
    }
}
