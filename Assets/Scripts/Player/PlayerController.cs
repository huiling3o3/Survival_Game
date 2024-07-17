using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string currentCharacter;
    string currentWeapon;
    [SerializeField] float currentHp;

    [SerializeField] float MaxHP;

    [SerializeField] StatusBar hpBar;

    //references
    PlayerMovement pm;

    private void Awake()
    {
        //set all the references connected to the player interactions
        pm = GetComponent<PlayerMovement>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        //set player initial position
        transform.position = Vector2.zero;
        //set the variables of the default val of the player stats to the player controller variables
    }

    public float GetMovementSpeed() => pm.moveSpeed;
    public float GetMaxHp() => MaxHP;
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

    public float GetCurrentHp()
    {
        return currentHp;
    }

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
