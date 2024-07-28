using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : WeaponController
{
    private Animator anim;
    public void Start()
    {
        init();        
    }
    public override void init()
    {
        base.init();
        anim = GetComponent<Animator>();
    }

    protected override void DoAttack()
    {
        //reset the cooldown
        base.DoAttack();

        //Set speed of the animator to play animation        
        anim.speed = speed;

        //get the player transform
        Vector3 direction = Game.GetPlayer().GetMoveDir();
        float dirX = direction.x;

        //Change the direction of the weapon based on the player movement
        if (dirX < 0) //left
        {
            anim.SetTrigger("AttackLeft");
        }
        else if (dirX > 0)
        {
            anim.SetTrigger("AttackRight");
        }
        else
        {
            anim.SetTrigger("AttackLeft");
        }

        //initialise the melee weapon behaviour to damage the enemy
        prefab.GetComponent<AxeBehaviour>().init(this);
    }
}
