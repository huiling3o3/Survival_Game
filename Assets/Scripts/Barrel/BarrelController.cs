using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField] int hitPoints = 3; // The number of hits the barrel can take
    [SerializeField] float dropRate = 0.5f; // Probability of dropping a health potion (0.5 means 50%)

    public GameObject healthPotionPrefab; // The health potion prefab

    public void TakeHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            DropHealthPotion();
        }
    }

    void DropHealthPotion()
    {
        if (Random.value <= dropRate)
        {
            Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
        }
    }
}
