using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField]float healthpoint; //0.5f => 50% increase
    protected void OnTriggerEnter2D(Collider2D col)
    {
        //Reference the script from the collided collider and deal damage using TakeDamage()
        if (col.CompareTag("Player"))
        {
            PlayerController playerController = col.GetComponent<PlayerController>();
            if (playerController != null) 
            {
                playerController.IncreaseHealth(healthpoint);
            }
        }
    }
}
