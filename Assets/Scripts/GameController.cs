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

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
 
    //initial character 
    public string initCharacter;
    public string initWeapon;
    private void Awake()
    {
        Game.SetGameController(this);
        dm.GetComponent<Database>();
        dm.SetDatabase();
        pc = playerObj.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartGame();       
        //Debug.Log("Enemies " + Game.GetEnemyList().Count);

        //Create new player
        Game.SetPlayer(new Player(initCharacter));
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {              
        //set player initial position
        playerObj.transform.position = Vector2.zero;

        //initialie the player
        pc.Init();

        //set input handler to player movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());

        //update the UI
        Game.GetHUDController().UpdatePlayerStats();
    }
}
