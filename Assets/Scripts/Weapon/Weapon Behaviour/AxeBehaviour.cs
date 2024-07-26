using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MeleeWeaponBehaviour
{
    private WaitForSeconds delay = new WaitForSeconds(3f);
    public override void init(WeaponController wc)
    {
        StartCoroutine(StayActive());
        this.wc = wc;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }

    private IEnumerator StayActive()
    { 
        gameObject.SetActive(true);
        yield return delay;
        gameObject.SetActive(false);
    }
}
