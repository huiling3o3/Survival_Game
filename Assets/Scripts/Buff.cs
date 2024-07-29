using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public string id { get; }
    public buffName name { get; }
    public buffType bufftype { get; }
    public float buffValue { get; }

    public Buff(string id, buffName name, buffType bType, float buffValue)
    {
        this.id = id;
        this.name = name;
        this.bufftype = bType;
        this.buffValue = buffValue;
    }

    //HP & SPEED - FOR CHARACTER ONLY, ATK & COOLDOWN IS FOR WEAPON ONLY
    public enum buffName
    { 
        HP,
        ATK,
        SPEED,
        COOLDOWN
    }
    public enum buffType
    {
        CHARACTER,
        WEAPON
    }
}
