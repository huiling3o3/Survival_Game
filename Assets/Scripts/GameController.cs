using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerObj;
    PlayerController pc;
    public InputHandler inputHandler;
    public Database dm;
    private bool gameIsActive = false;
 
    //initial character 
    public string initCharacter;
    public string initWeapon;

    private void Awake()
    {
        Game.SetGameController(this);
        dm.GetComponent<Database>();
        dm.SetDatabase();
        pc = playerObj.GetComponent<PlayerController>();

        //Set the initial character to be unlocked for the player to select
        Character character = Game.GetCharacterByRefID(initCharacter);
        character.locked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Open character select menu
        Game.GetHUDController().OpenCharacterSelectMenu();
        StartGame();       
        //Debug.Log("Enemies " + Game.GetEnemyList().Count)             
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void StartGame()
    {
        CreatePlayer();


    }

    public void CreatePlayer()
    {
        //Create new player and set the static reference in Game
        Game.SetPlayer(new Player(initCharacter));

        //initialise the player
        pc.Init();

        //set input handler to player movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());
    }
    public void SetCharacter(string characterId)
    {
        Game.GetPlayer().ChangeCurrentCharacter(characterId);
        //update the UI
        Game.GetHUDController().UpdatePlayerStats();
        //close menu
        Game.GetHUDController().CloseCharacterSelectMenu();
    }

    public bool CheckInitialCharacter(string id)
    {
        if (initCharacter == id)
            return true;
        else return false;
    }
}
