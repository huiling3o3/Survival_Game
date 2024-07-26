using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    [SerializeField] RuntimeAnimatorController[] characterAnimatorList;
    // Start is called before the first frame update
    void Awake()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeAnimator(string characterName)
    {
        //Joy Update this with 3 more characters
        if (characterAnimatorList.Length != 0)
        {
            if (characterName == "Red Riding Hood")
            {
                am.runtimeAnimatorController = characterAnimatorList[0];
            }

            else if (characterName == "Blacksmith")
            {
                am.runtimeAnimatorController = characterAnimatorList[1];
            }

            else if (characterName == "Librarian")
            {
                am.runtimeAnimatorController = characterAnimatorList[2];
            }

        }        
    }
        
    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);

            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
