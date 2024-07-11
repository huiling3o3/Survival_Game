using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
