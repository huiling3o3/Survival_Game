using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The base script for the type of unit is in the game: Characters, enemy*/
public class Unit
{
    public enum UnitType
    {
        Character,
        Enemy,
    }

    public string id { get;}
    public string name { get;}
    public string description { get;}
    public UnitType unitType { get; set; }
    public int hp { get; set; }
    public int atk { get; set; }
    //public int atkRange { get; set; }
    //public int atkInterval { get; set; }
    public float moveSpeed { get; set; }

    public Unit() { }

    public Unit(string id, string name, string desc, UnitType unitType, int hp, int atk, float moveSpeed)
    {
        this.id = id;
        this.name = name;
        this.description = desc;
        this.unitType = unitType;
        this.hp = hp;
        this.atk = atk;
        //this.atkRange = atkRange;
        //this.atkInterval = atkInterval;
        this.moveSpeed = moveSpeed;
    }

    public virtual string GetStatString()
    {
        return "";
    }


}
