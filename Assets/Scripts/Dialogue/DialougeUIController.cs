using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Reflection;
using UnityEngine.Events;

public class DialogueUIController : MonoBehaviour, IInputReceiver
{
    //References to the text UI
    public TextMeshProUGUI characterText;
    public TextMeshProUGUI contentText;

    //list to contain the value
    private Queue<Dialogue> DialogueDataListQueue = new Queue<Dialogue>();

    //list to check the 
    Dialogue currentDialogue;

    //reference to current NPCDialogueController 
    NPCDialogueController currentNPC;

    public float textSpeed;

    [SerializeField]
    private bool isTyping;

    private void Awake()
    {
        //remember to keep this on in the scene editor
        Game.SetDialogueUIController(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if (contentText == null)
        {
            Debug.LogError("contentText is not assigned!");
            return;
        }

        if (characterText == null)
        {
            Debug.LogError("characterText is not assigned!");
            return;
        }

        contentText.text = string.Empty;
    }

    public void DoMoveDir(Vector2 aDir)
    {
        //do nothing
    }

    public void DoLeftAction()
    {

    }

    public void DoRightAction()
    {

    }

    public void DoSubmitAction()
    {
        if (isTyping)
        {
            // Show the whole text
            StopAllCoroutines();
            if (currentDialogue != null)
            {
                contentText.text = currentDialogue.speech;
                isTyping = false;
            }
            
        }
        else
        {
            NextLine();
        }
    }

    public void DoCancelAction()
    {
        
    }

    public void StartDialogue(Queue<Dialogue> qd, NPCDialogueController npc)
    {
        if (qd != null)
        {
            DialogueDataListQueue = qd;
            Debug.Log($"Entered {DialogueDataListQueue.Count} data");
        }
        else
            throw new Exception("No dialogue queue found");

        //Show the Dialogue Panel
        gameObject.SetActive(true);

        //Set the current npc
        currentNPC = npc;
        //Retrieve the current line
        currentDialogue = DialogueDataListQueue.Dequeue();
        //set the character name
        characterText.text = currentDialogue.GetCharacterName();
        //reset the text UI
        contentText.text = string.Empty;
        //Start typing out the text
        StartCoroutine(TypeLine(currentDialogue.speech));
    }

    void NextLine()
    {
        if (DialogueDataListQueue.Count != 0)
        {
            Debug.Log("moving to the next line ");
            //Retrieve the current line
            currentDialogue = DialogueDataListQueue.Dequeue();
            //set the character name
            characterText.text = currentDialogue.GetCharacterName();
            //reset the text UI
            contentText.text = string.Empty;
            //Start typing out the text
            Debug.Log("dialogue test: " + currentDialogue.speech);
            //Start typing out the text
            StartCoroutine(TypeLine(currentDialogue.speech));
        }
        else
        {
            Debug.Log("End of conversation");
            gameObject.SetActive(false);
            //Clear the queue
            DialogueDataListQueue.Clear();
            //Give the player control again
            Game.GetGameController().SetPlayerInputReciever();
            // Notify NPCDialogueController that the conversation has ended
            currentNPC.EndConversation();
        }
    }

    IEnumerator TypeLine(string text)
    {
        isTyping = true;
        Debug.Log("Coroutine started for typing line: " + text);

        // Type each character one by one
        foreach (char c in text.ToCharArray())
        {
            contentText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        ShowClickIndicator(); // Indicate that the user can click to advance
    }

    void ShowClickIndicator()
    {
        // Implement your method to show visual feedback here
        // For example, showing a flashing icon or changing the cursor
        Debug.Log("User can click to advance the dialogue.");
    }
}

