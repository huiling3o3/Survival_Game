using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    //references
    [SerializeField]
    PlayerMovement pm;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void DoAttack()
    {
        base.DoAttack();
        GameObject spawnedKnife = Instantiate(prefab);
        //assigned the spawn knife to shoot from the weapon position
        spawnedKnife.transform.position = transform.position;

        //reference the player moving direction to shoot the knife
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
