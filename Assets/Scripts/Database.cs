using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Runtime.InteropServices.ComTypes;

/// <summary>
/// Contains all the method that read the file from the CSV and set it into the Game
/// </summary>
public class Database : MonoBehaviour
{
    public string characterFilePath = "";
    public string buffFilePath = "";
    public string enemyFilePath = "";
    public string weaponFilePath = "";
    public string analyticsTracking = "";

    //Demo purpose
    public List<Character> characterList;
    public List<Buff> buffList;
    public List<Enemy> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        //WriteFile(analyticsTracking);
        characterList =  GetCharacterList();
        //enemyList = GetEnemyList();
        foreach (Character chara in characterList)
        {
            Debug.Log($"id: {chara.id} name: {chara.name} desc: {chara.description} hp: {chara.hp} movepeed: {chara.moveSpeed}");
            Debug.Log(chara.locked);
        }
        //ReadFile(enemyFilePath);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ReadFile(string filepath)
    {
        using (StreamReader sr = new StreamReader(filepath))
        {
            while (!sr.EndOfStream) //reading the file and haven't reach the end
            {
                Debug.Log(sr.ReadLine());
            }
        }
    }

    //example of how to write file
    public void WriteFile(string filepath)
    {
        using (StreamWriter sw = new StreamWriter(filepath, true))
        {
            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(i.ToString() + ",hello, dear, my");
            }
        }

    }

    public void SetDatabase()
    {
        //set the charcterlist into the game references
        Game.SetCharacterList(GetCharacterList());
        Game.SetEnemyList(GetEnemyList());
        //Game.SetBuffList(GetBuffList());
    }

    public List<Character> GetCharacterList()
    {
        List<Character> characterList = new List<Character>();

        //Check if file exist
        if (File.Exists(characterFilePath))
        {

            using (StreamReader sr = new StreamReader(characterFilePath))
            {
                string line = "";
                bool isFirstLine = true;

                while (!sr.EndOfStream) //reading the file and haven't reach the end
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            // Skip the header line
                            isFirstLine = false;
                            continue;
                        }

                        //Split the data into an array of attributes
                        string[] fields = line.Split(',');

                        //assign the attributes
                        string id = fields[0];
                        string name = fields[1];
                        string desc = fields[2];
                        int hp = int.Parse(fields[3]);
                        float moveSpeed = float.Parse(fields[4]);
                        int atk = int.Parse(fields[5]);
                        //int atkRange = int.Parse(fields[5]);
                        //int atkInterval = int.Parse(fields[6]);


                        Debug.Log($"ADD Character id: {id} name: {name} desc: {desc} hp: {hp} movepeed: {moveSpeed}");

                        //Create the new character based on the data
                        //string id, string name, string desc, int hp, int atk, int atkRange, int atkInterval, float moveSpeed
                        Character character = new Character(id, name, desc, hp, atk, moveSpeed);
                        characterList.Add(character);
                    }

                }

            }
        }

        return characterList;
    }

    public List<Buff> GetBuffList()
    {
        List<Buff> buffList = new List<Buff>();

        //Check if file exist
        if (File.Exists(buffFilePath))
        {

            using (StreamReader sr = new StreamReader(buffFilePath))
            {
                string line = "";
                bool isFirstLine = true;

                while (!sr.EndOfStream) //reading the file and haven't reach the end
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            // Skip the header line
                            isFirstLine = false;
                            continue;
                        }

                        //Split the data into an array of attributes
                        string[] fields = line.Split(',');

                        //assign the attributes
                        string id = fields[0];
                        string name = fields[1];
                        string type = fields[2].ToUpper();
                        float buffValue = float.Parse(fields[3]);

                        Buff.BuffType buffType = (Buff.BuffType)System.Enum.Parse(typeof(Buff.BuffType), type);

                        Debug.Log($"id: {id} name: {name} buff Type: {buffType} Buff Value: {buffValue}");

                        //Create the new buff based on the data
                        Buff buff = new Buff(id, name, buffType, buffValue);
                        buffList.Add(buff);
                    }

                }
            }
        }

        return buffList;
    }

    public List<Enemy> GetEnemyList()
    {
        List<Enemy> enemyList = new List<Enemy>();
        //Check if file exist
        if (File.Exists(enemyFilePath))
        {

            using (StreamReader sr = new StreamReader(enemyFilePath))
            {
                string line = "";
                bool isFirstLine = true;

                while (!sr.EndOfStream) //reading the file and haven't reach the end
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            // Skip the header line
                            isFirstLine = false;
                            continue;
                        }

                        //Split the data into an array of attributes
                        string[] fields = line.Split(',');

                        //assign the attributes
                        string id = fields[0];
                        string name = fields[1];
                        string desc = fields[2];
                        int hp = int.Parse(fields[3]);
                        int atk = int.Parse(fields[4]);
                        float moveSpeed = float.Parse(fields[5]);

                        Debug.Log($"ADD enemy id: {id} name: {name} desc: {desc} hp: {hp} movepeed: {moveSpeed}");
                        //Create the new enemy based on the data
                        //string id, string name, string desc, int hp, int atk, float moveSpeed
                        Enemy enemy = new Enemy(id, name, desc, hp, atk, moveSpeed);
                        enemyList.Add(enemy);
                    }

                }

            }
            
        }
        return enemyList;
    }
}


