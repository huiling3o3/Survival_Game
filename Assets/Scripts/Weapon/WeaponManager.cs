using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains the list of all the weapon prefab
public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<GameObject> WeaponPrefabList;

    public void Awake()
    {
        Game.SetWeaponManager(this);
    }

    public GameObject GetWeaponPrefab(string weaponName)
    {
        if (WeaponPrefabList.Count != 0)
        {
            switch (weaponName)
            {
                case "Knife":
                    return WeaponPrefabList[0];
                case "Force Field":
                    return WeaponPrefabList[1];
                case "Axe":
                    return WeaponPrefabList[2];
            }
            Debug.Log("no weapon found!");
            return null;
        }
        else
        { Debug.Log("weapon list is empty!"); return null;}
    }

}
