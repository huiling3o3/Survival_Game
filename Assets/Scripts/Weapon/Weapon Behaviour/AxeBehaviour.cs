using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : MeleeWeaponBehaviour
{
    private WaitForSeconds delay = new WaitForSeconds(3f);
    public override void init(WeaponController wc)
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(StayActive());
        }
        else
        {
            Debug.LogWarning("Cannot start coroutine because the GameObject is inactive!");
        }
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
