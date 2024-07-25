using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

/// <summary>
/// Contains all the method that read the file from the CSV and set it into the Game
/// </summary>
public class Database : MonoBehaviour
{
    string characterFilePath = "Assets/CSV/CharacterRef.csv";
    string buffFilePath = "";
    string enemyFilePath = "Assets/CSV/EnemyRef.csv";
    string weaponFilePath = "Assets/CSV/WeaponRef.csv";
    string waveFilePath = "Assets/CSV/WaveRef.csv";
    string barrelFilePath = "Assets/CSV/BarrelRef.csv";
    string analyticsTracking = "Assets/CSV/Analytics.csv";

    // Start is called before the first frame update
    void Start()
    {
        //WriteFile(analyticsTracking);
        //characterList =  GetCharacterList();
        //enemyList = GetEnemyList();
        //foreach (Character chara in characterList)
        //{
        //    Debug.Log($"id: {chara.id} name: {chara.name} desc: {chara.description} hp: {chara.hp} movepeed: {chara.moveSpeed}");
        //    Debug.Log(chara.id);
        //}
        //ReadFile(enemyFilePath);
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
        Debug.Log("Adding Data into Game");
        //set the charcterlist into the game references
        Game.SetCharacterList(GetCharacterList());
        Game.SetEnemyList(GetEnemyList());
        Game.SetWeaponList(GetWeaponList());
        Game.SetBarrelList(GetBarrelList());
        Game.SetWaveDataList(GetWaveDataList());
        Debug.Log("Data added successfully into Game");

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


                        //Debug.Log($"ADD Character id: {id} name: {name} desc: {desc} hp: {hp} movepeed: {moveSpeed}");

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

                        //Debug.Log($"id: {id} name: {name} buff Type: {buffType} Buff Value: {buffValue}");

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
                        int atkCooldown = int.Parse(fields[6]);

                        //Debug.Log($"ADD enemy id: {id} name: {name} desc: {desc} hp: {hp} movespeed: {moveSpeed} cooldown: {atkCooldown}");
                        //Create the new enemy based on the data
                        //string id, string name, string desc, int hp, int atk, float moveSpeed
                        Enemy enemy = new Enemy(id, name, desc, hp, atk, moveSpeed, atkCooldown);
                        enemyList.Add(enemy);
                    }

                }

            }
            
        }
        return enemyList;
    }

    public List<Weapon> GetWeaponList()
    {
        List<Weapon> weaponList = new List<Weapon>();
        //Check if file exist
        if (File.Exists(weaponFilePath))
        {
            using (StreamReader sr = new StreamReader(weaponFilePath))
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

                        //weaponID,weaponName,weaponDescription,weaponType,weaponATK,weaponRange,weaponSpeed,weaponCoolDown

                        //assign the attributes
                        string id = fields[0];
                        string name = fields[1];
                        string desc = fields[2];
                        string type = fields[3];
                        Weapon.WeaponType weaponType = (Weapon.WeaponType)System.Enum.Parse(typeof(Weapon.WeaponType), type);
                        int atk = int.Parse(fields[4]);
                        int range = int.Parse(fields[5]);
                        int speed = int.Parse(fields[6]);
                        int cooldown = int.Parse(fields[7]);

                        //Debug.Log($"ADD weapon id: {id} name: {name} desc: {desc} weapontype: {type} atk power: {atk} cooldown: {cooldown}");
                        //Create the new enemy based on the data
                        //string id, string name, string desc, int hp, int atk, float moveSpeed
                        Weapon weapon = new Weapon(id, name, desc, weaponType, atk, range, speed, cooldown);
                        weaponList.Add(weapon);
                    }

                }

            }

        }
        return weaponList;
    }

    public List<WaveData> GetWaveDataList()
    {
        List<WaveData> waveDataList = new List<WaveData>();

        if (File.Exists(waveFilePath))
        {
            using (StreamReader sr = new StreamReader(waveFilePath))
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
                        string waveID = fields[0];
                        int waveNumber = int.Parse(fields[1]);
                        string enemyID = fields[2];
                        int enemyCount = int.Parse(fields[3]);
                        string barrelID = fields[4];
                        int barrelCount = int.Parse(fields[5]);
                        //Debug.Log($"ADD wave id: {waveID} wave number: {waveNumber} enemy id: {enemyID} enemy count: {enemyCount} barrel id {barrelID} barrel count: {barrelCount}");

                        //Create the new wave based on the data
                        WaveData wave = new WaveData(waveID, waveNumber, enemyID, enemyCount,barrelID,barrelCount);
                        waveDataList.Add(wave);
                    }
                }
            }
        }
        return waveDataList;
    }

    public List<Barrel> GetBarrelList()
    {
        List<Barrel> barrelList = new List<Barrel>();

        //Check if file exist
        if (File.Exists(barrelFilePath))
        {

            using (StreamReader sr = new StreamReader(barrelFilePath))
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
                        int hitPoint = int.Parse(fields[1]);
                        float healthPoint = float.Parse(fields[2]);

                        //Create the new barrel based on the data
                        //string id, int hitpoint, float health point
                        //Debug.Log($"ADD barrel id: {id} hit point: {hitPoint} health point: {healthPoint}");
                        Barrel barrel = new Barrel(id, hitPoint, healthPoint);
                        barrelList.Add(barrel);
                    }

                }

            }
        }

        return barrelList;
    }
}


