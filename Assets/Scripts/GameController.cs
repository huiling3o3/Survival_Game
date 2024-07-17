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

    [SerializeField]
    private Transform[] Spawnlocation;

    //initial character 
    public string initCharacter;
    public string initWeapon;

    float timer = 0f;
    private void Awake()
    {
        Game.SetGameController(this);       
        dm.GetComponent<Database>();
        dm.SetDatabase();
        pc = playerObj.GetComponent<PlayerController>();
        Game.SetPlayer(pc);

        //Set the initial character to be unlocked for the player to select
        Character character = Game.GetCharacterByRefID(initCharacter);
        character.locked = false;
    }

    private EnemySpawner enemySpawner;
    private float timeBetweenSpawn = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //Open character select menu
        Game.GetHUDController().OpenCharacterSelectMenu();
        StartGame();
        //Debug.Log("Enemies " + Game.GetEnemyList().Count)
        enemySpawner = Game.GetEnemySpawner();
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
                enemySpawner.SpawnEnemy("Guy Zombies", Spawnlocation[rand]);
                timer = 0f;
            }
        }
    }  

    public void StartGame()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        //initialise the player
        pc.Init();

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
    }

    public void SetWeapon(string weaponId)
    { 
    
    }

    public bool CheckInitialCharacter(string id)
    {
        if (initCharacter == id)
            return true;
        else return false;
    }
}
