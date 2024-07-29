using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private string weaponID;
    void Start()
    {
       
    }

    public void OpenChest()
    {
        // Display the reward selection UI
        Debug.Log("Chest opened. Select your reward!");
        //Game.GetHUDController().OpenChestItemSelectMenu();

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Interact with the Chest UI
            OpenChest();
        }
    }
}
