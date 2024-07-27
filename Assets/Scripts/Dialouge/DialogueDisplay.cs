// DIALOGUE SYSTEM made by James Shipp
// Last updated 9/28/23

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

/*
 * This script should go on an instance of the DialogueCanvas
 * prefab. It controls the display of text from NPCDialogueManagers
 * and facilitates the opening and closing of the dialogue box
 * and associated side effects! 
 */
public class DialogueDisplay : MonoBehaviour, IInputReceiver
{
    // references set up in the inspector
    [SerializeField]
    private TMP_Text dialogueText;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField, Tooltip("Length of delay between dialogue box open animation starting and text beginning to type")]
    private float openAnimationLength;
    [SerializeField, Tooltip("Length of delay between dialogue box close animation starting canvas being switched off")]
    private float closeAnimationLength;

    // text parsing bookkeeping
    public bool active;
    bool typing = false;
    float talkspeed = 80f;
    private int lineIndex;
    private Dialogue currentConvo;

    public UnityEvent OnDialogueCompletion;

    // text lerp in effect variables
    Mesh mesh;
    Vector3[] vertices;
    int characterCount = 0;
    float xTracker = 0f;
    float shiftDistance = 5f;

    private void Awake()
    {
        //Game.SetDialogueDisplay(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        lineIndex = 0;
        currentConvo = null;

        GetComponent<Canvas>().enabled = false;
        dialogueText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (typing)
                {
                    characterCount = dialogueText.textInfo.characterCount - 1;
                }
                else
                    ShowNextLine();
            }

            if (!typing)
                return;

            dialogueText.ForceMeshUpdate();
            mesh = dialogueText.mesh;
            vertices = mesh.vertices;

            Color[] colors = mesh.colors;

            // keep already typed characters black
            for (int i = 0; i < characterCount; i++)
            {
                TMP_CharacterInfo completedChar = dialogueText.textInfo.characterInfo[i];

                int completedCharIndex = completedChar.vertexIndex;
                colors[completedCharIndex] = Color.black;
                colors[completedCharIndex + 1] = Color.black;
                colors[completedCharIndex + 2] = Color.black;
                colors[completedCharIndex + 3] = Color.black;
            }

            // lerp in current character
            if (dialogueText.textInfo.characterInfo[characterCount].isVisible)
            {
                xTracker -= Time.deltaTime * talkspeed;
                float lerpProgress = xTracker / shiftDistance;

                Vector3 offset = new Vector3(Mathf.Lerp(0, shiftDistance, lerpProgress), 0f, 0f);
                int index = dialogueText.textInfo.characterInfo[characterCount].vertexIndex;

                // slide character over
                vertices[index] += offset;
                vertices[index + 1] += offset;
                vertices[index + 2] += offset;
                vertices[index + 3] += offset;

                // lerp transparent -> black
                colors[index] = Color.Lerp(Color.black, Color.clear, lerpProgress);
                colors[index + 1] = Color.Lerp(Color.black, Color.clear, lerpProgress);
                colors[index + 2] = Color.Lerp(Color.black, Color.clear, lerpProgress);
                colors[index + 3] = Color.Lerp(Color.black, Color.clear, lerpProgress);

                if (xTracker <= 0)
                {
                    NextCharacter();
                }
            }
            else
                NextCharacter();

            mesh.vertices = vertices;
            mesh.colors = colors;
            dialogueText.canvasRenderer.SetMesh(mesh);
        }
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
        if (typing)
        {
            characterCount = dialogueText.textInfo.characterCount - 1;
        }
        else
            ShowNextLine();
    }

    public void DoCancelAction()
    {
        CloseDisplay();
    }

    // called by an NPCDialogueManager to display a conversation.
    // opens the dialogue box and begins displaying text
    public void ActivateDisplay(Dialogue convo)
    {
        if (convo == null)
            throw new Exception("Activated dialogue display for nonexistant conversation");

        currentConvo = convo;
        nameText.text = convo.GetCharacterName();
        lineIndex = 0;
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().SetBool("activate", true);
        StartCoroutine(BeginText());
    }

    private IEnumerator BeginText()
    {
        yield return new WaitForSeconds(openAnimationLength);
        dialogueText.gameObject.SetActive(true);
        ShowNextLine();
        active = true;
    }

    private void ShowNextLine()
    {
        if (currentConvo == null)
        {
            CloseDisplay();
            return;
        }

        typing = true;
        characterCount = 0;
        dialogueText.color = Color.clear;
        dialogueText.text = currentConvo.speech;
        lineIndex++;
    }

    private void NextCharacter()
    {
        characterCount++;
        if (characterCount >= dialogueText.textInfo.characterCount)
            typing = false;
        else
            xTracker = shiftDistance;
    }

    public void CloseDisplay()
    {
        StartCoroutine(DelayedClose());
        GetComponent<Animator>().SetBool("activate", false);
       
        dialogueText.gameObject.SetActive(false);
        active = false;
    }

    private IEnumerator DelayedClose()
    {
        yield return new WaitForSeconds(closeAnimationLength);
        GetComponent<Canvas>().enabled = false;
        OnDialogueCompletion.Invoke();
    }
}
