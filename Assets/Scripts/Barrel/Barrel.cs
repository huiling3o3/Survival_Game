using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel
{
    public string id { get; }
    public int hitPoints { get; }
    public float healthPoint { get;}
    public Barrel(string id, int hitPoints, float healthPoint)
    {
        this.id = id;
        this.hitPoints = hitPoints;
        this.healthPoint = healthPoint;
    }
}


