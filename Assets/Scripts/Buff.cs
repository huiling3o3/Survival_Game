using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public string id { get; }
    public string name { get; }
    public BuffType buffType { get; }
    public float buffValue { get; }

    public Buff(string id, string name, BuffType buffType, float buffValue)
    {
        this.id = id;
        this.name = name;
        this.buffType = buffType;
        this.buffValue = buffValue;
    }

    public enum BuffType
    { 
        HP,
        ATK,
        SPEED,
        RATE,
        RANGE
    }
}
