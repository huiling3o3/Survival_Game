using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private GameObject blacksmithNPC; // reference to the Blacksmith 
    [SerializeField] private GameObject librarianNPC; // reference to the Librarian 

    private void Awake()
    {
        Game.SetNPCManager(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        // ensure both NPCs are toggled off before start of game
        librarianNPC.SetActive(false);
        blacksmithNPC.SetActive(false);
    }

    public void StartDialogue()
    {
        blacksmithNPC.SetActive(true);
    }

    // method to check if the blacksmith dialogue is complete
    public void CompleteBlacksmithDialogue()
    {
        librarianNPC.SetActive(true); 
        blacksmithNPC.SetActive(false); 
    }

    // method to check if the librarian dialogue is complete
    public void CompleteLibrarianDialogue()
    {
        librarianNPC.SetActive(false); 
        Game.GetGameController().DialogueCompleted();
    }

}
