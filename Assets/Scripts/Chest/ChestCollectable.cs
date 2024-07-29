using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Huiling, Joy
public class ChestCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Debug.Log("Encountered player");
            //Get the Chest from the Chest Manager
            Game.GetChestManager().GetChest();
            Destroy(gameObject);
        }
    }
}
