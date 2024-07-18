using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData
{
    public string waveID { get; }
    public int waveNumber { get; }
    public string EnemyID { get; }
    public int enemyCount { get; }


    public WaveData(string waveID, int waveNumber, string enemyID, int enemyCount)
    {
        this.waveID = waveID;
        this.waveNumber = waveNumber;
        this.EnemyID = enemyID;
        this.enemyCount = enemyCount;
    }

}
