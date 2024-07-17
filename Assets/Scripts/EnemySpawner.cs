using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    private void Awake()
    {
        Game.SetEnemySpawner(this);
    }
    public void SpawnEnemy(string enemyName, Transform spawnLocation)
    {
        //Search through database for the enemy name and return value based on the corresponding entry in the database 

        GameObject spawn = Instantiate(enemyPrefab, spawnLocation);


        //Look through the database for the list of enemies
        foreach (Enemy enemy in Game.GetEnemyList())
        {
            if (enemy.name == enemyName)
            {
                Debug.Log($"Found {enemy.name}");
                //Call the set stats function in the enemycontroller to set its stats based on the database
                spawn.GetComponent<EnemyController>().Init();
                spawn.GetComponent<EnemyController>().SetStats(enemy.hp, enemy.atk, enemy.moveSpeed, enemy.atkCooldown);
                //spawn.GetComponent<EnemyController>().enabled = true;
            }
        }
    }
}
