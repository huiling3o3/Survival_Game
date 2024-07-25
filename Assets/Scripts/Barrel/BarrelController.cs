using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField] Sprite[] barrelSprites;
    [SerializeField] GameObject healthPotionPrefab; // The health potion prefab  
    [SerializeField] float healthPoint; //the health points to pass in the health potion
    [SerializeField] int currentHitPoints = 0; // The number of hits the barrel can take
    public void SetStats(int hitPts, float healthPt)
    {
        currentHitPoints = hitPts;
        healthPoint = healthPt;
        GetComponent<SpriteRenderer>().sprite = barrelSprites[0];
    }

    public void TakeHit()
    {
        --currentHitPoints;

        //change the sprite according to the number of hits
        if (currentHitPoints <= 0)
        {
            DropHealthPotion();
            Destroy(gameObject);          
        }
        else if (currentHitPoints <= 1)
        {
            GetComponent<SpriteRenderer>().sprite = barrelSprites[2];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = barrelSprites[1];
        }
    }

    void DropHealthPotion()
    {
        GameObject hc_gameObject = Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
        HealthCollectable hc = hc_gameObject.GetComponent<HealthCollectable>();
        if (hc != null) 
        {
            // set the health point
            hc.SetHP(healthPoint);            
        }
        
    }
}
