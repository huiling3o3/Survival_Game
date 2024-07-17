using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public enum WeaponType
    {
        Ranged,
        Melee,
    }

    public string id { get; }
    public string name { get; }
    public string description { get; }
    public WeaponType type { get; }
    public int atk { get; }
    public int ranged { get; }
    public float speed { get; }
    public int cooldown { get; }

    public Weapon (string id, string name, string description, WeaponType type, int atk, int ranged, float speed, int cooldown)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.atk = atk;
        this.ranged = ranged;
        this.speed = speed;
        this.cooldown = cooldown;
    }
}
