using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, IInputReceiver
{
    //References
    private Rigidbody2D rb;

    //Movement
    public float moveSpeed;

    [HideInInspector]
    public Vector2 moveDir { get; set; }
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;
    void Start()
    {
        //set up the rigidbody
        rb = GetComponent<Rigidbody2D>();
        //Store the last moved vector, so when the projectile weapon move it will not remain 0 
        lastMovedVector = new Vector2(1, 0f);
        moveDir = Vector2.zero;
    }

    public void ChangeMovementSpeed(float newMoveSpeed)
    {
        if (moveSpeed != 0)
        {
            moveSpeed = newMoveSpeed;
        }
    }

    #region Input handling

    public void DoMoveDir(Vector2 aDir)
    {
        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }

        //get the movement direction
        moveDir = aDir;
       
        moveDir = Vector2.ClampMagnitude(moveDir, 0.1f);

        //normalize it to prevent diagonal movement being faster
        moveDir = moveDir.normalized;

        // Move the player object using MovePosition function of Rigidbody2D
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
             
    }
    public void DoLeftAction()
    {
        //do nothing
    }

    public void DoRightAction()
    {
        //do nothing
    }

    public void DoSubmitAction()
    {
        //do nothing
    }

    public void DoCancelAction()
    {
        //pause game
        Game.GetGameController().OpenPauseMenu();
    }

    #endregion Input handling
}