using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//base script of all the projectile [to be placed on the prefab of the weapon that is a projectile]
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;
    protected WeaponController wc;
    public virtual void init(WeaponController wc)
    {
        Destroy(gameObject, destroyAfterSeconds);
        this.wc = wc;
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        //By default the knife is on the right pos
        //To set the knife to switch to the correct direction, Manually adjust the position based on player movement direction 

        //left
        if (dirX < 0 && dirY == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dirX > 0 && dirY > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dirX > 0 && dirY < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        //Set the game object position and rotation
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
