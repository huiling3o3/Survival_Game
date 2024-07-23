using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //references to assigned
    public GameObject playerObj;    
    public InputHandler inputHandler;
    Database dm;
    PlayerController pc;
    //bool gameIsActive = false;

    [SerializeField]
    private Transform[] Spawnlocation;

    //initial character & weapon
    public string initCharacter;
    public string initWeapon;

    float timer = 0f;
    private EnemySpawner enemySpawner;
    private float timeBetweenSpawn = 10f;

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
        if (timer < timeBetweenSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenSpawn)
            {
                Debug.Log("Enemy Spawned");
                int rand = Random.Range(0, 3);
                enemySpawner.SpawnEnemy("e101", Spawnlocation[rand]);
                //timer = 0f;
            }
        }
    }  

    public void StartGame()
    {
        //set player initial weapon
        SetWeapon(initWeapon);
        SetWeapon("w103");
        //spawn the enemy
        enemySpawner = Game.GetEnemySpawner();
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
}
