using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    float minTravelDistance = 2f;
    Vector2 boundaryMin, boundaryMax;

    [SerializeField]
    private List<GameObject> spawnedBarrel = new List<GameObject>(); //List to contain all spawned barrel

    // Start is called before the first frame update
    void Awake()
    {
        Game.SetBarrelSpawner(this);
        //set game boundary according to camera boundary (for fixed camera)
        Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        boundaryMin = mainCamera.ViewportToWorldPoint(new Vector2(0.1f, 0.1f));
        boundaryMax = mainCamera.ViewportToWorldPoint(new Vector2(0.9f, 0.9f));
    }

    public void ClearSpawnedBarrel()
    {
        if (spawnedBarrel.Count != 0)
        {
            for (int i = 0; i < spawnedBarrel.Count; i++)
            {
                Destroy(spawnedBarrel[i]);
            }

            //clear list
            spawnedBarrel.Clear();
        }

    }

    //randomize position a minimum distance away from a given point
    private Vector2 GetRandomPos(Vector2 avoidPos)
    {
        Vector2 randomPos = avoidPos;

        //loop while randomPos is too close to avoidPos
        while (Vector2.Distance(randomPos, avoidPos) <= minTravelDistance)
        {
            //randomize a position within game boundary
            randomPos = new Vector2(Random.Range(boundaryMin.x, boundaryMax.x), Random.Range(boundaryMin.y, boundaryMax.y));
        }

        return randomPos;
    }

    public void SpawnBarrel(string barrelID)
    {
        GameObject spawn = Instantiate(barrelPrefab);
        //Set the spawn position to a random position based on the map position
        spawn.transform.position = GetRandomPos(Game.GetPlayer().GetMoveDir());

        //set the barrel stats and start its function
        Barrel barrel = Game.GetBarrelByRefID(barrelID);
        spawn.GetComponent<BarrelController>().SetStats(barrel.hitPoints, barrel.healthPoint);
        spawnedBarrel.Add(spawn); //Adds to the list of barrel
    }
}
