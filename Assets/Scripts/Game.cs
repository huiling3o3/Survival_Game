using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class to store all the static object that can be access anywhere in the scene
public static class Game
{
    //private static PlayerController player;
    private static Player mainPlayer;
    private static List<Character> characterList;
    private static List<Buff> buffList;

    /// <summary>
    /// Player get and set
    /// </summary>
    /// <returns></returns>
    public static Player GetPlayer()
    {
        return mainPlayer;
    }

    public static void SetPlayer(Player Player)
    {
        mainPlayer = Player;
    }

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

    public static string GetSystemTime()
    {
        return System.DateTime.Now.ToString();
    }
}
