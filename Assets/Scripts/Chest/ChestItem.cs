using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Progress;
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
    
    public void SetItemID(string id)
    {
        //TODO #4: Currently the Button name is set to the item name
        // I need you to Change it based on the what the buff does and what what object
        //example: like the on button click code, based on the item name
        //change the text to either "Get a {weapon name} weapon"/ "Upgrade your health to {buff val}"
        //the string id is how you get the info, so if it is weapon it is a weapon id
        //if it is a buff then you need to check the buff type/name 

        ItemID = id;
        // stylise the button
        buttonText.text = "Get " + itemName.ToString();
    }

    void OnButtonClick()
    {
        //Debug.Log("Button was clicked!");
        //Set the different function based on the itemtype
        switch (itemName)
        {
            //TODO #3
            case itemType.New_Weapon:
                //Call the method from Game controller to set weapon and pass in the item ID
                break;
            case itemType.Weapon_Buff:
                //Call the method from Game controller to set weapon buff and pass in the item ID
                break;
            case itemType.Character_Buff:
                //Call the method from Game controller to set character buff and pass in the item ID
                break;
        }
        Debug.Log("Open");
        Game.GetHUDController().CloseChestItemSelectMenu();
    }
}
