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
    public int atkRange;
    public float cooldownDuration;
    float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //set the current cool down to the cool down duration
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            //DoAttack();
        }
        
    }

    public void SetStats(int damage, float speed,int atkRange,float cooldown)
    {
        this.damage = damage;

        this.speed = speed;

        this.atkRange = atkRange;
        //Set the collider to the atk range
        this.transform.localScale = new Vector3((float)atkRange, (float)atkRange, (float)atkRange);

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
        if (col.CompareTag("Enemy"))
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                DoAttack();
            }
        }
    }
}
