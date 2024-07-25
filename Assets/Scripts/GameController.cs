using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //references to assigned
    public GameObject playerObj;    
    public InputHandler inputHandler;
    Database dm;
    PlayerController pc;
    bool gameIsActive = false;

    //initial character & weapon
    public string initCharacter;
    public string initWeapon;
    
    //Game Controller Variables
    public int numOfEnemiesKilled;

    private void Awake()
    {
        //Set the reference to Game
        Game.SetGameController(this);

        //set up the database
        dm = GetComponent<Database>();
        dm.SetDatabase();

        //Set reference for the player
        pc = playerObj.GetComponent<PlayerController>();
        Game.SetPlayer(pc);

        //Set the initial character to be unlocked for the player to select
        Character character = Game.GetCharacterByRefID(initCharacter);
        character.locked = false;

        //initialise the player
        pc.Init();
    }

    
    // Start is called before the first frame update
    void Start()
    {        
        //Open character select menu
        Game.GetHUDController().OpenCharacterSelectMenu();        
    }


    // Update is called once per frame
    void Update()
    {
       
    }  

    public void StartGame()
    {
        //set player initial weapon
        SetWeapon(initWeapon);
        //set the second weapon 
        SetWeapon("w103");

        //call the wave manager to start the wave of enemies
        Game.GetWaveManager().NextWave();
        
        //update the HUD manager to update the UI
        Game.GetHUDController().UpdateWaveStats(Game.GetWaveManager().GetCurrentWave(), Game.GetWaveManager().GetEnemyCountInWave());

        //set input handler to player movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());
    }  

    public void SetCharacter(string characterId)
    {
        //update the player stats with the character selected info
        Game.GetPlayer().ChangeCharacter(characterId);       
        //update the UI
        Game.GetHUDController().UpdatePlayerStats();
        //close menu
        Game.GetHUDController().CloseCharacterSelectMenu();

        StartGame();
    }

    public void SetWeapon(string weaponId)
    {
        string weaponName = Game.GetWeaponByRefID(weaponId).name;
        Game.GetPlayer().AddWeapon(weaponId, Game.GetWeaponManager().GetWeaponPrefab(weaponName));
    }

    public bool CheckInitialCharacter(string id) 
    {
        if (initCharacter == id)
            return true;
        else return false;
    }

    public void EnemyKilled()
    {
        numOfEnemiesKilled++;       

        //Check if all the current wave of enemies are killed if killed 
        if (numOfEnemiesKilled == Game.GetWaveManager().GetEnemyCountInWave())
        {
            //call the wave manager to start the next wave of enemies
            Game.GetWaveManager().NextWave();
            //reset the number of enemies killed
            numOfEnemiesKilled = 0;
        }

        //update the HUD manager to update the UI on the wave stats to get the number of enemies left 
        Game.GetHUDController().UpdateWaveStats(Game.GetWaveManager().GetCurrentWave(), Game.GetWaveManager().GetEnemyCountInWave() - numOfEnemiesKilled);
    }

    #region Menus
    public void ResumeGame()
    {
        //unpause game
        Time.timeScale = 1f;
        gameIsActive = true;

        //set input handler to movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());

        //close pause menu
        //ClosePauseMenu();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameIsActive = false;
    }

    public void ClosePauseMenu()
    {
        //menuSceneManager.CloseMenuScene("PauseMenuScene");
    }
    #endregion
}
