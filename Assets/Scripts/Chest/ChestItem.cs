using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class ChestItem : MonoBehaviour
{
    [Header("Not To be assigned")]
    [SerializeField]
    private string ItemID;
    [Header("To be assigned")]
    [SerializeField]
    private TextMeshProUGUI buttonText;
    //To be adjusted in the inspector
    public itemType itemName; //this can be either Character Buff/New Weapon/WeaponBuff
    Button thisbtn;
    private WeaponController wc;

    public enum itemType
    {
        Character_Buff,
        New_Weapon,
        Weapon_Buff
    }

    // Start is called before the first frame update
    void Start()
    {
        thisbtn = GetComponent<Button>();
        // Add a listener to the onClick event
        thisbtn.onClick.AddListener(OnButtonClick);
    }

    //Method to set the ItemID and update the button text
    public void SetItemID(string id)
    {
        //set the value of the item
        ItemID = id;

        //reset the button as interactable
        //thisbtn.interactable = true;

        // stylise the button
        switch (itemName)
        {
            case itemType.New_Weapon:

                if (ItemID == "")
                {
                    Debug.Log("no new weapon to get");
                    //Set the button as uninteractable
                    thisbtn.interactable = false;
                    buttonText.text = "no new weapon to get";
                }
                else
                {
                    // Get the weapon by ID
                    Weapon weapon = Game.GetWeaponByRefID(ItemID);
                    if (weapon != null)
                    {
                        // Set the button text for the weapon
                        buttonText.text = $"Get a {weapon.name} weapon";
                    }
                }
                break;
            case itemType.Weapon_Buff:
                Buff weaponBuff = Game.GetBuffByRefID(ItemID);
                if (weaponBuff != null && weaponBuff.bufftype == Buff.buffType.WEAPON)
                {
                    // Get the player weapon controller
                    GetPlayerWeaponController();

                    if (wc != null)
                    {
                        // Set the button text for the weapon buff
                        buttonText.text = $"Upgrade your {wc.GetWeaponName()}'s {weaponBuff.name} by {weaponBuff.buffValue}";
                    }
                    else
                    {
                        buttonText.text = "Not eligible weapon for buff";
                    }
                }
                else
                {
                    buttonText.text = "Invalid Buff Type";
                }
                break;
            case itemType.Character_Buff:
                Buff characterBuff = Game.GetBuffByRefID(ItemID);
                if (characterBuff != null && characterBuff.bufftype == Buff.buffType.CHARACTER)
                {
                    // Set the button text for the character buff
                    buttonText.text = $"Upgrade your max {characterBuff.name} by {characterBuff.buffValue}";
                }
                else
                {
                    buttonText.text = "Invalid Buff Type";
                }
                break;
        }
        
    }

    void OnButtonClick()
    {
        //Set the different function based on the itemtype
        switch (itemName)
        {
            case itemType.New_Weapon:
                //Equip the new weapon by setting it in the game controller
                Game.GetGameController().SetWeapon(ItemID);
                break;
            case itemType.Weapon_Buff:
                SetWeaponBuff();
                break;
            case itemType.Character_Buff:
                SetCharacterBuff();
                break;
        }
        Debug.Log("Open");
        Game.GetHUDController().CloseChestItemSelectMenu();
    }

    public void GetPlayerWeaponController()
    {
        //Get the total number of player's weapon
        int totalPlayerWeapon = Game.GetPlayer().GetWeaponCount();
        WeaponController WeaponCtrl = null;
        for (int i = 1; i <= totalPlayerWeapon; i++)
        {
            WeaponCtrl = Game.GetPlayer().GetWeaponByIndex(i);
            if (WeaponCtrl.CheckMaxBuffLvl())
            {
                WeaponCtrl = null;
                continue;
            }
            else 
            {
                break;
            }
        }

        if (WeaponCtrl == null)
        {            
            Debug.Log("No weapons to buff anymore...");
            //Set the button as uninteractable
            thisbtn.interactable = false;
        }
        else 
        {
            wc = WeaponCtrl;
        }
    }

    //Method to apply the weapon buff to the selected weapon
    public void SetWeaponBuff()
    {
        Buff weaponBuff = Game.GetBuffByRefID(ItemID);
        Debug.Log($"Buff name: {weaponBuff.name} type: {weaponBuff.bufftype} value: {weaponBuff.buffValue}");
        //Apply the buff upgrade to the weapon using the weapon controller
        wc.BuffUpgrade(weaponBuff);
    }

    //Method to apply the character buff to the player's character
    public void SetCharacterBuff()
    {
        Buff characterBuff = Game.GetBuffByRefID(ItemID);
        Debug.Log($"Buff name: {characterBuff.name} type: {characterBuff.bufftype} value: {characterBuff.buffValue}");
        //Upgrade the player's character stats with the buff
        Game.GetPlayer().UpgradeCharacterStats(characterBuff);
    }
}
