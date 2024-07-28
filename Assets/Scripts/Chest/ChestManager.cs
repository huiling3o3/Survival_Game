using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    private List<Buff> bufflist;

    [Header("To be assigned")]
    [SerializeField]
    private ChestItem[] chestItemList;

    private void Awake()
    {
        Game.SetChestManager(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        bufflist = Game.GetBuffList();
    }

    private void Update()
    {
        //for debugging purpose only
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            //GetChest();
        }
    }

    public void GetChest()
    {
        SetChestItem(GetNewWeapon(), GetCharacterBuff(), GetWeaponBuff());
        Game.GetHUDController().OpenChestItemSelectMenu();
    }

    private string GetNewWeapon()
    {
        List<Weapon> weapons = Game.GetWeaponList();
        
        //Set the initial random weapon
        int rand = Random.Range(0, weapons.Count);
        Weapon newWeapon = weapons[rand];

        Debug.Log($"Weapon {newWeapon.name} exist: "+ Game.GetPlayer().CheckWeaponExist(newWeapon.id));
        
        //Check if the weapon exist in the player's weapon list
        //if yes Keep looping
        while (Game.GetPlayer().CheckWeaponExist(newWeapon.id))
        {
            rand = Random.Range(0, weapons.Count);
            newWeapon = weapons[rand];
        }

        //otherwise return the new weapon found
        Debug.Log($"new weapon: {newWeapon.name}");
        return newWeapon.id;
    }

    private string GetCharacterBuff()
    {
        List<Buff> charBuffList = new List<Buff>();

        //filtered out the list of character buff
        for (int i = 0; i < bufflist.Count; i++)
        {
            if (bufflist[i].bufftype == Buff.buffType.CHARACTER)
            {
                charBuffList.Add(bufflist[i]);
            }
        }

        //Get a random buff
        int rand = Random.Range(0, charBuffList.Count);
        Buff newBuff = charBuffList[rand];

        return newBuff.id;
    }

    private string GetWeaponBuff()
    {
        List<Buff> weaponBuffList = new List<Buff>();

        //filtered out the list of character buff
        for (int i = 0; i < bufflist.Count; i++)
        {
            if (bufflist[i].bufftype == Buff.buffType.WEAPON)
            {
                weaponBuffList.Add(bufflist[i]);
            }
        }

        //Get a random buff
        int rand = Random.Range(0, weaponBuffList.Count);
        Buff newBuff = weaponBuffList[rand];

        return newBuff.id;
    }

    //set the chest item inside UI
    public void SetChestItem(string weaponID, string charBuffId, string weaponBuffId)
    {
        Debug.Log("chest name: " + chestItemList[0].itemName);
        foreach (ChestItem item in chestItemList)
        {
            switch (item.itemName)
            {
                case ChestItem.itemType.New_Weapon:
                    item.SetItemID(weaponID);
                    break;
                case ChestItem.itemType.Weapon_Buff:
                    item.SetItemID(weaponBuffId);                    
                    break;
                case ChestItem.itemType.Character_Buff:
                    item.SetItemID(charBuffId);
                    break;
            }
        }

    }
}
