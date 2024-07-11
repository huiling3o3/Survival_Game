using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private IInputReceiver activeReceiver;
    private Vector2 moveDir;

    public void SetInputReceiver(IInputReceiver inputReceiver)
    {
        //set current input receiver (to control 1 thing at a time)
        activeReceiver = inputReceiver;
    }

    void FixedUpdate()
    {
        if (activeReceiver == null) return;

        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        moveDir = new Vector2(horiInput, vertInput);
        activeReceiver.DoMoveDir(moveDir);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeReceiver == null) return;

        //TASK 1a: Get input keys
        //Using Unity Input Manager (Edit -> Project Settings -> Input Manager), without changing default values,
        //receive input for left and right directional keys (for menus, not movement),
        //and submit and cancel keys. Input should be detected when the key is pressed down.
        //Call the functions DoRightAction, DoLeftAction, DoSubmitAction
        //and DoCancelAction of the active InputReceiver as needed.
        //Check the fields within this class to see how you can access the active receiver.
        //Check the assignment document for details about which button inputs should be used for each function.

        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
        //    activeReceiver.DoMoveDir(moveDir);
        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            activeReceiver.DoLeftAction();  
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            activeReceiver.DoRightAction();
        }
        if (Input.GetButtonDown("Submit"))
        {
            activeReceiver.DoSubmitAction();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            activeReceiver.DoCancelAction();
        }
    }
}