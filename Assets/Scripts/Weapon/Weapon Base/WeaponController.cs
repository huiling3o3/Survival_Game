using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
/// 
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;

    public int damage; //atk
    public float speed;
    public float atkRange;// the radius of the attack range
    public float cooldownDuration;
    float currentCooldown;
    int minAtkRmage = 2;
    int maxAtkRmage = 10;

    public virtual void init()
    {
        //set the current cool down to the cool down duration
        currentCooldown = cooldownDuration;
    }
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)   //Once the cooldown becomes 0, attack
        {
            DoAttack();
        }
    }

    public void SetStats(int damage, float speed,int range,float cooldown)
    {
        this.damage = damage;

        this.speed = speed;

        this.atkRange = 2f * range;

        //Set the collider to the atk range
        this.transform.localScale = new Vector3(atkRange, atkRange, atkRange);

        this.cooldownDuration = cooldown;

        //set the current cool down to the cool down duration
        currentCooldown = cooldownDuration;
    }

    protected virtual void DoAttack()
    {
        //reset the cooldown time
        currentCooldown = cooldownDuration;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the enemy is within range to ATTACK
        //if (col.CompareTag("Enemy"))
        //{
        //    currentCooldown -= Time.deltaTime;
        //    if (currentCooldown <= 0f)
        //    {
        //        DoAttack();
        //    }
        //}
    }
}
