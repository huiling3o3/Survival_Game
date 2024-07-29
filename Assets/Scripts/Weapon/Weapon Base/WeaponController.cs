using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
/// 
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    [SerializeField]
    protected string weaponName;
    [SerializeField]
    protected int damage; //atk
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float cooldownDuration;
    [SerializeField]
    float currentCooldown;
    private int maxBuffLvl = 3;
    [SerializeField]
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

    public string GetWeaponName() => weaponName;
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

    public void BuffUpgrade(Buff buff)
    {
        if (CheckMaxBuffLvl())
            return;

        switch (buff.name)
        {
            case Buff.buffName.ATK:
                damage += (int)buff.buffValue;
                break;
            case Buff.buffName.SPEED:
                speed += buff.buffValue;
                break;
            case Buff.buffName.COOLDOWN:
                float newCoolDown = cooldownDuration - (buff.buffValue * 0.5f);
                if (newCoolDown <= 0.1f) // Ensuring a minimum cooldown duration
                {
                    newCoolDown = 0.1f;
                }
                cooldownDuration = newCoolDown;
                break;
        }

        currentBuffLvl++;
    }

    public void SetStats(string name, int damage, float speed,float cooldown)
    {
        this.weaponName = name;

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
