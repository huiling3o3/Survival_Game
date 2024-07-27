using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class ChestItemSelect : MonoBehaviour
{
    private List<Buff> allBuffs = Game.GetBuffList();
    private List<Weapon> weapons = Game.GetWeaponList();

    private List<Buff> characterBuff = new List<Buff>();
    private List<Buff> weaponBuff = new List<Buff>();

    Button thisbtn;
    Button characterBuffButton;
    Button weaponBuffButton;
    Button weaponButton;


    private void Start()
    {
        //SplitBuffs(allBuffs);
        thisbtn = GetComponent<Button>();
        thisbtn.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        //Debug.Log("Button was clicked!");
        //Set the player character to the characterID;
        Debug.Log("Open");
        Game.GetHUDController().CloseChestItemSelectMenu();
        //Game.GetGameController().SetCharacter(characterId);
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
