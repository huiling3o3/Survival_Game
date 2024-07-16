using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float currentHp;

    [SerializeField] private float playerMaxHP;

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
        //set the variables of the default val of the player stats to the player controller variables
        SetPlayerIntialStat();
    }
    public void SetPlayerIntialStat()
    {
        //Assign the player health, speed, and damage point
        playerMaxHP = Game.GetPlayer().GetMaxHp();
        currentHp = playerMaxHP;
        pm.ChangeMovementSpeed(Game.GetPlayer().GetSpeed());
    }

    public float GetCurrentHp()
    {
        return currentHp;
    }

    public void DealDamage()
    { 
        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0) 
        {
            Debug.Log("Character dead");
        }

        //create an event subscription when player health is decreased
        hpBar.SetState(currentHp, playerMaxHP);
    }
}
