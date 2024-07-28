using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

// a class to store all the static object that can be access anywhere in the scene
public static class Game
{
    private static PlayerController mainPlayer;
    private static List<Character> characterList;
    private static List<Buff> buffList;
    private static List<Enemy> enemyList;
    private static List<Weapon> weaponList;
    private static List<Barrel> barrelList;
    private static List<WaveData> waveDataList;
    private static List<Dialogue> dialogueList;
    private static WeaponManager weaponManager;
    private static GameController gameController;
    private static HUDController hudController;
    private static EnemySpawner enemySpawner;
    private static BarrelRandomizer barrelRandomizer;
    private static BarrelSpawner barrelSpawner;
    private static WaveManager waveManager;
    private static NPCDialogueController dialogueController;
    private static DialogueUIController dialogueUIController;
    private static NPCManager npcManager;
    private static ChestManager chestManager;
    public static WeaponManager GetWeaponManager() => weaponManager;
    public static void SetWeaponManager(WeaponManager wm) => weaponManager = wm;
    public static BarrelRandomizer GetBarrelRandomizer() => barrelRandomizer;
    public static void SetBarrelRandomizer(BarrelRandomizer br) => barrelRandomizer = br;
    public static EnemySpawner GetEnemySpawner() => enemySpawner;
    public static void SetEnemySpawner(EnemySpawner es) => enemySpawner = es;
    public static BarrelSpawner GetBarrelSpawner() => barrelSpawner;
    public static void SetBarrelSpawner(BarrelSpawner bs) => barrelSpawner = bs;
    public static WaveManager GetWaveManager() => waveManager;
    public static void SetWaveManager(WaveManager wave) => waveManager = wave;
    public static NPCDialogueController GetNPCDialogueController() => dialogueController;
    public static void SetNPCDialogueController(NPCDialogueController dialouge) => dialogueController = dialouge;
    public static DialogueUIController GetDialogueUIController() => dialogueUIController;
    public static void SetDialogueUIController(DialogueUIController dialougeCtrl) => dialogueUIController = dialougeCtrl;
    public static ChestManager GetChestManager() => chestManager;
    public static void SetChestManager(ChestManager cm) => chestManager = cm;
    public static void SetNPCManager(NPCManager npcM) => npcManager = npcM;
    public static NPCManager GetNPCManager() => npcManager;

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
    public static List<Buff> GetBuffList() => buffList;
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

    #region barrel
    public static Barrel GetBarrelByRefID(string id)
    {
        return barrelList.Find(x => x.id == id);
    }
    public static List<Barrel> GetBarrelList() => barrelList;
    public static void SetBarrelList(List<Barrel> bList) => barrelList = bList;

    #endregion

    #region dialogue
    public static Dialogue GetDialogueByRefID(string cutsceneID)
    {
        return dialogueList.Find(x => x.cutsceneID == cutsceneID);
    }

    public static List <Dialogue> GetDialogueList() 
    {  
        return dialogueList; 
    }

    public static void SetDialogueList(List <Dialogue> dList)
    {
        dialogueList = dList;
    }
    #endregion
    public static string GetSystemTime()
    {
        return System.DateTime.Now.ToString();
    }
}
