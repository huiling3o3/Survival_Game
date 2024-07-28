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
        librarianNPC.SetActive(false);
        blacksmithNPC.SetActive(false);
    }

    public void StartDialogue()
    {
        blacksmithNPC.SetActive(true);
    }

    // Method to check if the blacksmith dialogue is complete
    public void CompleteBlacksmithDialogue()
    {
        librarianNPC.SetActive(true); // Activate the librarian NPC after the conversation is complete
        blacksmithNPC.SetActive(false);
    }

    public void CompleteLibrarianDialogue()
    {
        librarianNPC.SetActive(false);
        Game.GetGameController().DialogueCompleted();
    }

}
