using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Enemy(string id, string name, string desc, int hp, float moveSpeed) : base(id, name, desc, UnitType.Enemy, hp, moveSpeed) { }

}
