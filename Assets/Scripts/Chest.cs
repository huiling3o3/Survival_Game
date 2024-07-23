using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private List<Weapon> weapons;
    private List<Buff> playerBuff;
    private List<Buff> weaponBuff;

    void Start()
    {
        weapons = Game.GetWeaponList();
        List<Buff> allBuffs = Game.GetBuffList();
        weaponBuff = allBuffs.FindAll(buff => buff.buffType == Buff.BuffType.ATK || buff.buffType == Buff.BuffType.RANGE || buff.buffType == Buff.BuffType.RATE);
        playerBuff = allBuffs.FindAll(buff => buff.buffType == Buff.BuffType.HP || buff.buffType == Buff.BuffType.SPEED);

    }

    public void OpenChest()
    {
        // Display the reward selection UI
        Debug.Log("Chest opened. Select your reward!");
    }

    // Method to give the selected reward to the player
    public void GiveReward(int option)
    {
        switch (option)
        {
            case 0:
                if (weapons.Count > 0)
                {
                    Weapon newWeapon = weapons[Random.Range(0, weapons.Count)];
                    Debug.Log("Received Weapon: " + newWeapon.name);
                }
                break;
            case 1:
                if (weaponBuff.Count > 0)
                {
                    Buff newWeaponBuff = weaponBuff[Random.Range(0, weaponBuff.Count)];
                    Debug.Log("Received Weapon Buff: " + newWeaponBuff.name);
                }
                break;
            case 2:
                if (playerBuff.Count > 0)
                {
                    Buff newCharacterBuff = playerBuff[Random.Range(0, playerBuff.Count)];
                    Debug.Log("Received Character Buff: " + newCharacterBuff.name);
                }
                break;
        }
    }
}
