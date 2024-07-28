using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NPCDialogueManager : MonoBehaviour
{
    [SerializeField]
    private int cutsceneSetID;
    
    private List<Dialogue> dialogueDataList; // List to store dialogue data
    private Queue<Dialogue> DialogueDataListQueue = new Queue<Dialogue>();

    [SerializeField] private GameObject blacksmithNPC; // reference to the Blacksmith 
    [SerializeField] private GameObject librarianNPC; // reference to the Librarian 

    private bool hasTalkedToBlacksmith = false; // track if player has talked to the blacksmith
    private bool hasTalkedToLibrarian = false; // track if player has talked to the librarian

    private void Awake()
    {
        Game.SetNPCDialogueManager(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeDialogue();
        if (librarianNPC != null && cutsceneSetID == 101)
        {
            librarianNPC.SetActive(false); // ensure librarian is initially inactive
        }
    }

    private void Update()
    {
        //Debugging purpose
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //Game.GetDialogueUIController().StartDialogue(DialogueDataListQueue);
            //Game.GetGameController().SetDialogueReciever();
        }

        if (DialogueDataListQueue.Count == 0 && cutsceneSetID == 101 && !hasTalkedToBlacksmith)
        {
            CompleteBlacksmithDialogue();
        }

        if (DialogueDataListQueue.Count == 0 && cutsceneSetID == 102 && !hasTalkedToLibrarian)
        {
            CompleteLibrarianDialogue();
        }
    }

    private void InitializeDialogue()
    {
        dialogueDataList = Game.GetDialogueList();
        if (dialogueDataList != null)
        {
            Debug.Log("Added dialogue into the list");
        }
        else
        {
            Debug.Log("unable to find dialouge");
        }

        SetDialogue();
    }

    public Queue<Dialogue> GetDialogue()
    {
        if (DialogueDataListQueue.Count != 0)
        {
            return DialogueDataListQueue;
        }
        return null;
    }

    public void SetDialogue()
    {
        List<Dialogue> filteredList = new List<Dialogue>();
        //filter the list into the same set ID
        for (int i = 0; i < dialogueDataList.Count; i++)
        {
            Dialogue d = dialogueDataList[i];
            if (cutsceneSetID == d.cutsceneSetID)
            {
                filteredList.Add(d);
            }
        }

        //A variable to store the next cut scene id to arrange
        string nextDialogue = "";
        //arrange the dialogue according to the next cut scene id and set it into the queue
        for (int j = 0; j < filteredList.Count; j++)
        {            
            if (j == 0)
            {
                //set the first dialouge
                DialogueDataListQueue.Enqueue(filteredList[j]);
                nextDialogue = filteredList[j].nextCutsceneID;
            }

            //Set the dialogue based on the next cutsceneID
            if (filteredList[j].cutsceneID == nextDialogue)
            {
                DialogueDataListQueue.Enqueue(filteredList[j]);
                nextDialogue = filteredList[j].nextCutsceneID;
            }
        }

    }

    // Method to check if the blacksmith dialogue is complete
    private void CompleteBlacksmithDialogue()
    {
        hasTalkedToBlacksmith = true;
        librarianNPC.SetActive(true); // Activate the librarian NPC after the conversation is complete
        blacksmithNPC.SetActive(false);
    }

    private void CompleteLibrarianDialogue()
    {
        hasTalkedToLibrarian = true;
        //librarianNPC.SetActive(false);
        //Game.GetGameController().DialogueCompleted();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Encountered player");
            Game.GetDialogueUIController().StartDialogue(DialogueDataListQueue);
            Game.GetGameController().SetDialogueReciever();
        }
    }
}
