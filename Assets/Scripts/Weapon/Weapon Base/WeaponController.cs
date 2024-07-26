using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Pipeline;
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
    protected float cooldownDuration;
    float currentCooldown;

    private int maxBuffLvl = 3;
    private int currentBuffLvl = 1;

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

    public float GetWeaponSpeed() => speed;
    public int GetWeaponDamage() => damage;
    public float GetWeaponCoolDown() => cooldownDuration;

    public bool CheckMaxBuffLvl()
    {
        if (currentBuffLvl >= maxBuffLvl)
        {
            return true;
        }
        return false;
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

    public void SetStats(int damage, float speed,float cooldown)
    {
        this.damage = damage;

        this.speed = speed;

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
