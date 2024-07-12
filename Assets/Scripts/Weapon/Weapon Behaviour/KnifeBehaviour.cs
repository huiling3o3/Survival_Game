using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    KnifeController kc;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        kc = FindAnyObjectByType<KnifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the movement of the knife
        transform.position += direction * kc.speed * Time.deltaTime;
    }
}
