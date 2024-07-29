using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Huiling
public class KnifeController : WeaponController
{
    // Start is called before the first frame update
    public override void init()
    {
        base.init();
    }

    protected override void DoAttack()
    {
        base.DoAttack();
        GameObject spawnedKnife = Instantiate(prefab);
        //assigned the spawn knife to shoot from the weapon position
        spawnedKnife.transform.position = transform.position;
        KnifeBehaviour kb = spawnedKnife.GetComponent<KnifeBehaviour>();

        //initialise the projectile
        kb.init(this);
        //reference the player moving direction to shoot the knife
        kb.DirectionChecker(Game.GetPlayer().GetLastMovedVector());
    }
}
