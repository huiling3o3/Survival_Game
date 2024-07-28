using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class ChestItemSelect : MonoBehaviour
{
    //To be adjusted in the inspector
    [SerializeField]
    private itemType itemName; //this can be either Character Buff/New Weapon/WeaponBuff
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private List<Buff> allBuffs = Game.GetBuffList();

    private List<Weapon> availableWeaponList;

    private List<Buff> characterBuff = new List<Buff>();
    private List<Buff> weaponBuff = new List<Buff>();

    Button thisbtn;

    public enum itemType
    {
        Character_Buff,
        New_Weapon,
        Weapon_Buff
    }

    private void Start()
    {
        //SetAvailableWeapons();
        //SplitBuffs(allBuffs);
        thisbtn = GetComponent<Button>();
        //stylise the button
        buttonText.text = "Get " + itemName.ToString();
        // Add a listener to the onClick event
        thisbtn.onClick.AddListener(OnButtonClick);
    }

    public void initialised()
    {        
        // Add a listener to the onClick event
        thisbtn.onClick.AddListener(OnButtonClick);
    }

    

    void OnButtonClick()
    {
        //Debug.Log("Button was clicked!");
        //Set the player character to the characterID;
        Debug.Log("Open");
        Game.GetHUDController().CloseChestItemSelectMenu();
    }

    private void SplitBuffs(List<Buff> allBuffs)
    {
        foreach (var buff in allBuffs)
        {
            if (buff.bufftype == Buff.buffType.CHARACTER)
            {
                characterBuff.Add(buff);
            }
            else if (buff.bufftype == Buff.buffType.WEAPON)
            {
                weaponBuff.Add(buff);
            }
        }
    }
}
