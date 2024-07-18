using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        Game.SetBarrelSpawner(this);
    }

    public void SpawnBarrel(string spawnerID, Transform spawnLocation)
    {
        GameObject spawn = Instantiate(barrelPrefab);

        //foreach()
    }
}
