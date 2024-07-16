using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public string characterId;
    Character character;
    Button thisbtn;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    private void Start()
    {
        //Set up the button UI according to the character name 
        character = Game.GetCharacterByRefID(characterId);
        thisbtn = GetComponent<Button>();
        buttonText.text = character.name;
        UpdateBtnStatus();
        // Add a listener to the onClick event
        thisbtn.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        Debug.Log("Button was clicked!");
        //Set the player character to the characterID;
        Game.GetGameController().SetCharacter(characterId);
    }

    public void UpdateBtnStatus()
    {
        //Check if the character is locked if it is set the button to be non-interactable
        if (character.locked)
        {
            thisbtn.interactable = false;
        }
        else
        {
            thisbtn.interactable = true;
        }
    }
}
