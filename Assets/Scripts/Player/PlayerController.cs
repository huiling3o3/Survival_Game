using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string currentCharacter;
    List<string> weaponList;

    [SerializeField] float currentHp;

    [SerializeField] float MaxHP;

    [SerializeField] StatusBar hpBar;

    //references
    PlayerMovement pm;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        //set player initial position
        transform.position = Vector2.zero;
        //set all the references connected to the player interactions
        pm = GetComponent<PlayerMovement>();
    }

    #region Weapons
    public List<string> GetCurrentWeaponList() { return weaponList; }

    public void AddWeapon(string weapon)
    {
        weaponList.Add(weapon);

    }

    public void RemoveWeapon(string weapon)
    {
        weaponList.Remove(weapon);
    }
    public void ClearWeaponList()
    {
        weaponList.Clear();
    }

    #endregion

    #region character function
    public void ChangeCharacter(string currentCharacter)
    {
        this.currentCharacter = currentCharacter;

        //get the character id
        Character playerCharacter = Game.GetCharacterByRefID(this.currentCharacter);
        //change the player variables according to the character
        MaxHP = playerCharacter.hp;
        currentHp = MaxHP;
        pm.ChangeMovementSpeed(playerCharacter.moveSpeed);
    }

    public string GetCurrentCharacter()
    {
        return currentCharacter;
    }
    #endregion

    #region player stats function
    public float GetMovementSpeed() => pm.moveSpeed;
    public float GetMaxHp() => MaxHP;
    public float GetCurrentHp() => currentHp;

    #endregion
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0) 
        {
            Debug.Log("Character dead");
        }

        //create an event subscription when player health is decreased
        hpBar.SetState(currentHp, MaxHP);
    }
}
