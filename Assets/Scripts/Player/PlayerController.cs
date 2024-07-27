using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Dictionary<string, GameObject> PlayerWeapons = new Dictionary<string, GameObject>();

    [Header("Player Stats")]
    string currentCharacter;

    [SerializeField] float currentHp;

    [SerializeField] float MaxHP;

    [SerializeField] StatusBar hpBar;

    //references
    PlayerMovement pm;
    PlayerAnimator pa;
    public void Init()
    {
        //set player initial position
        transform.position = Vector2.zero;
        //set all the references connected to the player interactions
        pm = GetComponent<PlayerMovement>();
        pa = GetComponent<PlayerAnimator>();
    }

    #region Weapons
    public void AddWeapon(string weaponID, GameObject weaponPrefab)
    {
        if (!PlayerWeapons.ContainsKey(weaponID))
        {
            GameObject weaponInstance = Instantiate(weaponPrefab, transform);
            Debug.Log("weapon added success!");
            Weapon weapon = Game.GetWeaponByRefID(weaponID);
            //set the weapon details from the weapon class
            weaponInstance.GetComponent<WeaponController>().init();
            weaponInstance.GetComponent<WeaponController>().SetStats(weapon.atk, weapon.speed, weapon.cooldown);
            PlayerWeapons.Add(weaponID, weaponInstance);
        }
    }

    #endregion

    #region character function
    public void ChangeCharacter(string currentCharacter)
    {
        this.currentCharacter = currentCharacter;

        //get the character id
        Character playerCharacter = Game.GetCharacterByRefID(this.currentCharacter);

        //Swap the animator controller according to the character name
        pa.ChangeAnimator(playerCharacter.name);

        //Set characters stats
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
    public Vector2 GetLastMovedVector() => pm.lastMovedVector;
    public Vector2 GetMoveDir() => pm.moveDir;
    public void IncreaseHealth(float newHp) //newHp is in percentage
    {
        currentHp += currentHp * newHp;
        if (currentHp > MaxHP)
        { 
            currentHp = MaxHP;
        }

        //create an event subscription when player health is decreased
        hpBar.SetState(currentHp, MaxHP);
    }

    public void TakeDamage(int damage)
    {
        if (currentHp >= 0)
        {
            currentHp -= damage;
        }
        Debug.Log($"player took {damage} damage");
        if (currentHp <= 0)
        {
            Debug.Log("Character dead");
            Game.GetGameController().PlayerDied();
        }

        //create an event subscription when player health is decreased
        hpBar.SetState(currentHp, MaxHP);
    }

    #endregion
}
