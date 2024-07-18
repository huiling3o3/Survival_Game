using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    public override void init()
    {
        base.init();
    }

    protected override void DoAttack()
    {
        base.DoAttack();
        GameObject spawnedGarlic = Instantiate(prefab);
        //Assign the position to be the same as this object which is parented to the player
        //So when spawned, it will follow the player around
        spawnedGarlic.transform.position = transform.position; 
        spawnedGarlic.transform.parent = transform;
        //initialise the melee weapon behaviour
        spawnedGarlic.GetComponent<GarlicBehaviour>().init(this);
    }
}
