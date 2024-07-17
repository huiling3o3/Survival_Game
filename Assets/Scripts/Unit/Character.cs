using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : Unit
{
    public bool locked { get; set; }
    public Character(string id, string name, string desc, int hp, int atk, float moveSpeed) : base(id, name, desc, UnitType.Character, hp, atk, moveSpeed)
    {
        locked = true;
    }

    public override string GetStatString()
    {
        //Debug.Log($"id: {id} Name: {name} Desc: {desc} HP: {hp} MoveSpeed: {moveSpeed}");
        return "$\"id: {id} Name: {name} Desc: {desc} HP: {hp} MoveSpeed: {moveSpeed}\""; 
    }

}