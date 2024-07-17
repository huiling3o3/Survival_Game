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
                spawn = Instantiate(zombieGuyPrefab, spawnLocation);
                break;
            case "Zombie Girl":
                spawn = Instantiate(zombieGirlPrefab, spawnLocation);
                break;
            case "Big Bad Wolf":
                spawn = Instantiate(bossPrefab, spawnLocation);
                break;

        }

        spawn.GetComponent<EnemyController>().Init();
        spawn.GetComponent<EnemyController>().SetStats(enemy.hp, enemy.atk, enemy.moveSpeed, enemy.atkCooldown);
    }
}
