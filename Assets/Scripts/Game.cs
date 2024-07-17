using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class to store all the static object that can be access anywhere in the scene
public static class Game
{
    private static PlayerController mainPlayer;
    private static List<Character> characterList;
    private static List<Buff> buffList;
    private static List<Enemy> enemyList;
    private static List<Weapon> weaponList;
    private static GameController gameController;
    private static HUDController hudController;
    private static EnemySpawner enemySpawner;
    private static BarrelRandomizer barrelRandomizer;

    public static BarrelRandomizer GetBarrelRandomizer() => barrelRandomizer;
    public static void SetBarrelRandomizer(BarrelRandomizer br) => barrelRandomizer = br;

    public static EnemySpawner GetEnemySpawner() => enemySpawner;
    public static void SetEnemySpawner(EnemySpawner es) => enemySpawner = es;


    #region HUD
    public static HUDController GetHUDController() => hudController;
    public static void SetHUDController(HUDController hc) => hudController = hc;
    #endregion

    #region gamecontroller
    public static GameController GetGameController()
    {
        return gameController;
    }

    public static void SetGameController(GameController gc)
    {
        gameController = gc;
    }
    #endregion

    #region player
    /// <summary>
    /// Player get and set
    /// </summary>
    /// <returns></returns>
    public static PlayerController GetPlayer()
    {
        return mainPlayer;
    }

    public static void SetPlayer(PlayerController Player)
    {
        mainPlayer = Player;
    }

    #endregion

    #region character
    /// <summary>
    /// Character Set and Get
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //Get a single character
    public static Character GetCharacterByRefID(string id)
    {
        return characterList.Find(x => x.id == id);
    }

    public static List<Character> GetCharacterList()
    {
        return characterList;
    }

    public static void SetCharacterList(List<Character> cList)
    {
        characterList = cList;
    }

    #endregion

    #region buff
    /// <summary>
    /// Buff Set and Get
    /// </summary>
    /// <param name="bList"></param>
    public static void SetBuffList(List<Buff> bList) 
    {
        buffList = bList;
    }
    public static Buff GetBuffByRefID(string id)
    {
        return buffList.Find(x => x.id == id);
    }
    #endregion
    
    #region enemy
    /// Enemy Set and Get
    public static Enemy GetEnemyByRefID(string id)
    {
        return enemyList.Find(x => x.id == id);
    }
    public static List<Enemy> GetEnemyList()
    {
        return enemyList;
    }
    public static void SetEnemyList(List<Enemy> eList)
    {
        enemyList = eList;
        Debug.Log("Setting enemy list");
    }
    #endregion

    #region weapon
    public static Weapon GetWeaponByRefID(string id)
    {
        return weaponList.Find(x => x.id == id);
    }
    public static List<Weapon> GetWeaponList()
    {
        return weaponList;
    }
    public static void SetWeaponList(List<Weapon> wList)
    {
        weaponList = wList;
    }
    #endregion

    public static string GetSystemTime()
    {
        return System.DateTime.Now.ToString();
    }
}
