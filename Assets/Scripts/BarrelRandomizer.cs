using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRandomizer : MonoBehaviour
{
    public List<GameObject> barrelSpawnPoints;
    public List<GameObject> barrelPrefabs;

    void Start()
    {
        SpawnBarrels();
    }

    void Update()
    {
        
    }

    void SpawnBarrels()
    {
        foreach (GameObject barrel in barrelSpawnPoints)
        {
            int rand = Random.Range(0, barrelPrefabs.Count);
            GameObject Barrel = Instantiate(barrelPrefabs[rand], barrel.transform.position, Quaternion.identity);
            Barrel.transform.parent = barrel.transform;
        }
    }
}
