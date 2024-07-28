using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //references to assigned
    public GameObject playerObj;    
    public InputHandler inputHandler;
    private MenuSceneManager menuSceneManager;
    public DialogueUIController dialogueUIController;
    Database dm;
    PlayerController pc;

    //initial character & weapon
    public string initCharacter;
    public string initWeapon;
    
    //Game Controller Variables
    public int numOfEnemiesKilled = 0;
    public int totalNumEnemiesKilled = 0;
    private float gameTimer;
    private bool gameIsActive = false;
    public bool gameOver = false;
    private void Awake()
    {
        //Set the reference to Game
        Game.SetGameController(this);

        //set up the database
        dm = GetComponent<Database>();
        dm.SetDatabase();

        //Set reference for the player
        pc = playerObj.GetComponent<PlayerController>();
        //Set reference to the menu
        menuSceneManager = GetComponent<MenuSceneManager>();
        
        //get the character initial character
        Character character = Game.GetCharacterByRefID(initCharacter);     
    }

    
    // Start is called before the first frame update
    void Start()
    {
        //show start menu
        OpenStartMenu();
        //set reference to dialogue display
        dialogueUIController = Game.GetDialogueUIController();
        //initialise the player
        pc.Init();
        Game.SetPlayer(pc);
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameIsActive) return;
        //proceed game timers
        gameTimer += Time.deltaTime;
    }  

    public void StartGame()
    {
        CloseStartMenu();

        //resume Game
        ResumeGame();

        //set player initial weapon
        SetWeapon(initWeapon);
        //OpenDialogue();
        //Game.GetDialogueUIController().StartDialogue();
        //Open character select menu
        //Game.GetHUDController().OpenCharacterSelectMenu();       
    }

    public void StartWave()
    {
        Debug.Log("Game Controller: Calling Start Wave");
        //set player initial weapon
        SetWeapon(initWeapon);
        //set the second weapon 
        SetWeapon("w102");

        //RESET timers
        gameTimer = 0;
        //reset the number of enemies killed
        numOfEnemiesKilled = 0;
        totalNumEnemiesKilled = 0;
        //reset wave
        Game.GetWaveManager().WaveReset();

        //call the wave manager to start the wave of enemies
        Game.GetWaveManager().NextWave();

        //update the HUD manager to update the UI
        UpdateHUD(numOfEnemiesKilled);

        //resume Game
        ResumeGame();
    }

    public void SetCharacter(string characterId)
    {
        //update the player stats with the character selected info
        Game.GetPlayer().ChangeCharacter(characterId);

        //update the player UI sprite on the HP Bar
        Game.GetHUDController().ChangeCharacterSprite(characterId);

        //close menu
        Game.GetHUDController().CloseCharacterSelectMenu();

        StartWave();
    }

    public void SetWeapon(string weaponId)
    {
        string weaponName = Game.GetWeaponByRefID(weaponId).name;
        Game.GetPlayer().AddWeapon(weaponId, Game.GetWeaponManager().GetWeaponPrefab(weaponName));
    }

    //TODO #1
    public void SetWeaponBuff(string buffID)
    {
        //upgrade players first weapon
        //Get player first weapon, index starts with 1
        //Check if weapon has reach the max buff lvl if not 
        //then call the weapon method buffUpgrade and pass in the buff object
        Buff weaponBuff = Game.GetBuffByRefID(buffID);

        // Get the player's first weapon (index starts with 1)
        Weapon firstWeapon = Game.GetPlayer().GetWeaponByIndex(1);


    }

    //TODO #2
    public void SetCharacterBuff(string buffID)
    {
        //Get the buff based on the id
        Buff buff = Game.GetBuffByRefID(buffID);
        //Call the player controller and call its method upgrade character stats and pass in the buff val
        Game.GetPlayer().UpgradeCharacterStats(buff);
    }

    public bool CheckInitialCharacter(string id) 
    {
        if (initCharacter == id)
            return true;
        else return false;
    }

    public void GameOver()
    {
        gameOver = true;
        OpenStartMenu();
    }

    public void EnemyKilled()
    {
        numOfEnemiesKilled++;       
        totalNumEnemiesKilled++;
        //Check if all the current wave of enemies are killed if killed 
        if (numOfEnemiesKilled == Game.GetWaveManager().GetEnemyCountInWave())
        {
            //call the wave manager to start the next wave of enemies
            Game.GetWaveManager().NextWave();
            //reset the number of enemies killed
            numOfEnemiesKilled = 0;
        }

        //update the HUD manager to update the UI on the wave stats to get the number of enemies left 
        UpdateHUD(numOfEnemiesKilled);
    }
    public static void UpdateHUD(int numOfEnemiesKilled)
    {
        Game.GetHUDController().UpdateWaveStats(Game.GetWaveManager().GetCurrentWave(), Game.GetWaveManager().GetEnemyCountInWave() - numOfEnemiesKilled);
    }

    #region input
    public void SetDialogueReciever()
    {
        //set input receiver
        inputHandler.SetInputReceiver(dialogueUIController);
    }

    public void SetPlayerInputReciever()
    {
        //set input handler to movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>()); ;
    }
    #endregion

    #region Menus

    public void ResumeGame()
    {
        //unpause game
        Time.timeScale = 1f;
        gameIsActive = true;

        //set input handler to movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());

        //close pause menu
        ClosePauseMenu();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameIsActive = false;
    }

    public void ClosePauseMenu()
    {
        menuSceneManager.CloseMenuScene("PauseMenuScene");
    }

    public void OpenPauseMenu()
    {
        PauseGame();

        menuSceneManager.OpenMenuScene("PauseMenuScene", () =>
        {
            //initialize menu after scene finishes loading
            PauseMenuScript menuScript = FindObjectOfType<PauseMenuScript>();
            menuScript.InitializeMenu(this);

            inputHandler.SetInputReceiver(menuScript);
        });
    }

    public void OpenStartMenu()
    {
        PauseGame();

        ClosePauseMenu();

        menuSceneManager.OpenMenuScene("StartMenuScene", () =>
        {
            //initialize menu after scene finishes loading
            StartMenuScript menuScript = FindObjectOfType<StartMenuScript>();
            menuScript.InitializeMenu(this);

            //set input receiver
            inputHandler.SetInputReceiver(menuScript);
            menuScript.ShowStartMenu(Game.GetWaveManager().GetCurrentWave(),totalNumEnemiesKilled,gameTimer);
        });
    }

    public void CloseStartMenu()
    {
        menuSceneManager.CloseMenuScene("StartMenuScene");
    }

    #endregion
}
