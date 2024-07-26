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

    protected int damage; //atk
    protected float speed;
    protected float atkRange;// the radius of the attack range
    protected float cooldownDuration;
    float currentCooldown;

    protected int maxBuffLvl = 3;
    protected int currentBuffLvl = 1;
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

    public void BuffUpgrade(Buff.buffName name, int value)
    {
        switch (name)
        {
            case Buff.buffName.ATK:
                damage = value;
                break;
            case Buff.buffName.SPEED:
                speed = value;
                break;
            case Buff.buffName.COOLDOWN:
                speed = value;
                break;
        }
    }

    public void SetStats(int damage, float speed,int range,float cooldown)
    {
        this.damage = damage;

        this.speed = speed;

        this.atkRange = range;

        //Set the collider to the atk range
        //this.transform.localScale = new Vector3(atkRange, atkRange, atkRange);

        this.cooldownDuration = cooldown;

        //set the current cool down to the cool down duration
        currentCooldown = cooldownDuration;
    }

    protected virtual void DoAttack()
    {
        //reset the cooldown time
        currentCooldown = cooldownDuration;
    }
}
