using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Huiling
public class HealthCollectable : MonoBehaviour
{
    float healthpoint; //0.5f => 50% increase
    [SerializeField] Sprite[] HPSpritesPrefab;
    public void SetHP(float hp)
    {
        healthpoint = hp;
        //set the sprite according to the health point
        if (HPSpritesPrefab.Length != 0)
        {
            if (healthpoint == 0.25)
            {
                GetComponent<SpriteRenderer>().sprite = HPSpritesPrefab[0];
            }
            else if (healthpoint == 0.5)
            {
                GetComponent<SpriteRenderer>().sprite = HPSpritesPrefab[1];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = HPSpritesPrefab[2];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Reference the script from the collided collider and heal the player
        if (col.CompareTag("Player"))
        {
            //Debug.Log("Encountered player");
            PlayerController playerController = col.GetComponent<PlayerController>();
            if (playerController != null) 
            {
                playerController.IncreaseHealth(healthpoint);
                Destroy(gameObject);
            }
        }
    }
}
