using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerObj;
    public InputHandler inputHandler;
    public Database dm;
    public List<Character> characterList = new List<Character>();
    private bool gameIsActive = false;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
 
    //initial character 
    public string initCharacter;
    public List<string> initBuffList;

    private void Awake()
    {
        //database.GetComponent<Database>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
        dm.SetDatabase();
        Debug.Log("Character " + Game.GetCharacterList().Count);

        Game.SetPlayer(new Player(initCharacter, initBuffList));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {              
        //set player initial position
        playerObj.transform.position = Vector2.zero;

        //set input handler to player movement script
        inputHandler.SetInputReceiver(playerObj.GetComponent<PlayerMovement>());
    }
}
