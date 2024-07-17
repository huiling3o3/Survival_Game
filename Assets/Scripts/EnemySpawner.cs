using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject zombieGuyPrefab;
    GameObject zombieGirlPrefab;
    GameObject bossPrefab;

    private void Awake()
    {
        Game.SetEnemySpawner(this);
    }
    //change the enemy name to enemyID when change to wave manager
    public void SpawnEnemy(string enemyID, Transform spawnLocation)
    { 
        GameObject spawn = null;

        Enemy enemy = Game.GetEnemyByRefID(enemyID);

        //instantiate the prefab according to the name
        switch (enemy.name)
        {
            case "Guy Zombies":
                spawn = Instantiate(zombieGuyPrefab);
                break;
            case "Zombie Girl":
                spawn = Instantiate(zombieGirlPrefab);
                break;
            case "Big Bad Wolf":
                spawn = Instantiate(bossPrefab);
                break;

        }

        //Set the spawn position
        spawn.transform.position = spawnLocation.position;
        spawn.transform.parent = spawnLocation;
        //initialise the enemy stats and start its function
        spawn.GetComponent<EnemyController>().Init();
        spawn.GetComponent<EnemyController>().SetStats(enemy.hp, enemy.atk, enemy.moveSpeed, enemy.atkCooldown);
    }
}
