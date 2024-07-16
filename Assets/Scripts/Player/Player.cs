using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string currentCharacter;
    string currentWeapon;
    List<string> currentBuffList = new List<string>();
    List<string> currentWeaponList = new List<string>();
    float playerMaxHp;
    float playerSpeed;
    //float playerAtk;
    //float playerAtkInterval;
    //float playerAtkRange;
    int buffCount;

    bool statDirty; //track when the stats have been changed

    public Player(string currentAvatar)
    { 
        this.currentCharacter = currentAvatar;
        //UpdateStats();
        Character playerCharacter = Game.GetCharacterByRefID(currentCharacter);

        playerMaxHp = playerCharacter.hp;
        playerSpeed = playerCharacter.moveSpeed;
    }

    public string GetCurrentCharacter()
    {
        return currentCharacter;
    }

    public List<string> GetCurrentBuffList()
    {
        return currentBuffList;
    }

    #region Weapons
    public List<string> GetCurrentWeaponList() {  return currentWeaponList; }

    public void AddWeapon(string weapon)
    {
        currentWeaponList.Add(weapon);
    }

    public void RemoveWeapon(string weapon)
    {
        currentWeaponList.Remove(weapon);
    }
    public void ClearWeaponList()
    {
        currentWeaponList.Clear();
    }

    #endregion


    public void AddBuff(string buff)
    { 
        currentBuffList.Add(buff);

        statDirty = true;
    }

    public void RemoveBuff(string buff)
    {
        currentBuffList.Remove(buff);

        statDirty = true;
    }

    public void ClearBuffList()
    {
        currentBuffList.Clear();

        statDirty = true;
    }

    public bool UpdateStats()
    { 
        if(!statDirty) return false;

        Debug.Log("CALCULATE STATS");

        Character playerCharacter = Game.GetCharacterByRefID(currentCharacter);

        playerMaxHp = playerCharacter.hp;
        //playerAtk = playerCharacter.atk;
        playerSpeed = playerCharacter.moveSpeed;
        //playerAtkInterval = playerCharacter.atkInterval;
        //playerAtkRange = playerCharacter.atkRange;

        foreach (string buffId in currentBuffList)
        { 
            Buff buff = Game.GetBuffByRefID(buffId);

            switch (buff.buffType)
            {
                case Buff.BuffType.HP:
                    playerMaxHp *= Mathf.CeilToInt(1f + buff.buffValue);
                    break;
                case Buff.BuffType.ATK:
                    //playerAtk *= 1f + buff.buffValue; 
                    break;
                case Buff.BuffType.SPEED:
                    //playerSpeed *= 1f + buff.buffValue;
                    break;
                case Buff.BuffType.RATE:
                    //playerAtkInterval *= 1f + buff.buffValue;
                    break;
                case Buff.BuffType.RANGE:
                    //playerAtkRange *= 1f + buff.buffValue;
                    break;

            }
        }

        //set the stat dirty to false to show stats has been updated
        statDirty = false;

        return true;
    }

    public float GetMaxHp() 
    {
        //UpdateStats();
        return playerMaxHp;
    }   

    public float GetSpeed()
    {
        //UpdateStats();
        return playerSpeed;
    }

    //public float GetAtk()
    //{
    //    UpdateStats();
    //    return playerAtk;
    //}
    //public float GetAttackInterval()
    //{
    //    UpdateStats();
    //    return playerAtkInterval;
    //}

    //public float GetAtkRange()
    //{
    //    UpdateStats();
    //    return playerAtkRange;
    //}

}
