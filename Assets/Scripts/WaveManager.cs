using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script
    public Transform[] spawnLocations; // Array of spawn locations

    private List<WaveData> waveDataList; // List to store wave data
    private int currentWave = 0; // Current wave number

    public bool waveEnded = false; //Bool to check if wave has ended

    [SerializeField] private Database database;

    // Start is called before the first frame update
    void Start()
    {
        waveDataList = database.GetWaveDataList(); // Get wave data from Database
        StartCoroutine(SpawnWaves()); // Start the wave spawning coroutine
        Game.SetWaveManager(this);
    }

    // Coroutine to manage the spawning of waves
    private IEnumerator SpawnWaves()
    {
        while (currentWave < GetTotalWaves())
        {
            Debug.Log($"WaveManager: Starting wave {currentWave + 1}");
            List<WaveData> currentWaveData = waveDataList.FindAll(w => w.waveNumber == currentWave + 1);

            // Spawn enemies according to the current wave data
            foreach (var waveData in currentWaveData)
            {
                Debug.Log($"WaveManager: Spawning {waveData.enemyCount} enemies of type {waveData.EnemyID}");
                for (int i = 0; i < waveData.enemyCount; i++)
                {
                    // Spawn the enemy using the EnemySpawner script
                    Transform spawnLocation = GetRandomSpawnLocation();
                    enemySpawner.SpawnEnemy(waveData.EnemyID, spawnLocation);

                    // Wait a short delay between spawns
                    yield return new WaitForSeconds(5f);

                }
            }

            // Move to the next wave
            currentWave++;

            //Wait until the last enemy is defeated 
            yield return new WaitUntil(() => waveEnded = true);

            // Wait a delay before starting the next wave
            yield return new WaitForSeconds(2f);

            //Sets the bool to false for the next wave
            waveEnded = false;
        }
    }

    // Gets the total number of waves from the wave data list
    private int GetTotalWaves()
    {
        int totalWaves = 0;
        foreach (var waveData in waveDataList)
        {
            if (waveData.waveNumber > totalWaves)
            {
                totalWaves = waveData.waveNumber;
            }
        }
        return totalWaves;
    }

    // Gets a random spawn location from the array
    private Transform GetRandomSpawnLocation()
    {
        int index = Random.Range(0, spawnLocations.Length);
        return spawnLocations[index];
    }
}
