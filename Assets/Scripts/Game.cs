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
    private static List<WaveData> waveDataList;
    private static WeaponManager weaponManager;
    private static GameController gameController;
    private static HUDController hudController;
    private static EnemySpawner enemySpawner;
    private static BarrelRandomizer barrelRandomizer;

    public static WeaponManager GetWeaponManager() => weaponManager;
    public static void SetWeaponManager(WeaponManager wm) => weaponManager = wm;
    public static BarrelRandomizer GetBarrelRandomizer() => barrelRandomizer;
    public static void SetBarrelRandomizer(BarrelRandomizer br) => barrelRandomizer = br;
    public static EnemySpawner GetEnemySpawner() => enemySpawner;
    public static void SetEnemySpawner(EnemySpawner es) => enemySpawner = es;

    #region HUD
    public static HUDController GetHUDController() => hudController;
    public static void SetHUDController(HUDController hc) => hudController = hc;
    #endregion

    #region gamecontroller
    public static GameController GetGameController() => gameController;
    public static void SetGameController(GameController gc) => gameController = gc;
    #endregion

    #region player
    public static PlayerController GetPlayer() => mainPlayer;
    public static void SetPlayer(PlayerController Player) => mainPlayer = Player;   

    #endregion

    #region character
    //Get a single character
    public static Character GetCharacterByRefID(string id)
    {
        return characterList.Find(x => x.id == id);
    }

    public static List<Character> GetCharacterList() => characterList;

    public static void SetCharacterList(List<Character> cList) => characterList = cList;

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
    public static List<Weapon> GetWeaponList() => weaponList;
    public static void SetWeaponList(List<Weapon> wList) => weaponList = wList;

    #endregion

    #region enemyWave
    public static WaveData GetWaveByRefID(string waveID)
    {
        return waveDataList.Find(x => x.waveID == waveID);
    }
    public static List<WaveData> GetWaveDataList()
    {
        return waveDataList;
    }
    public static void SetWaveDataList(List<WaveData> wDList)
    {
        waveDataList = wDList;
    }
    #endregion

    public static string GetSystemTime()
    {
        return System.DateTime.Now.ToString();
    }
}
