using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerHP;

    PlayerMovement pm;
    PlayerAttack playerAttack;

    private void Awake()
    {
        //set all the references connected to the player interactions
        pm = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerStats(float hp, float speed)
    {
        //Assign the player health, speed, and damage point
        playerHP = hp;
        pm.ChangeMovementSpeed(speed);
    }

    public void DealDamage()
    { 
        
    }
}
