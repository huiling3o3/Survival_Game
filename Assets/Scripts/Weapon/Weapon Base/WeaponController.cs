using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int timeDisappear; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //set the current cool down to the cool down duration
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            DoAttack();
        }

        
    }
    protected virtual void DoAttack()
    {
        currentCooldown = cooldownDuration;
    }
}
