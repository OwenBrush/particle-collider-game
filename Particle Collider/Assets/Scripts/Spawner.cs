using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] ObjectPool spherePool;

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    [SerializeField] float xRange;
    [SerializeField] float yRange;

    private void Start()
    {
        Invoke("SpawnSphere",1);
    }

    private void SpawnSphere()
    {
        GameObject sphere = spherePool.GetPooledObject();
        if (sphere != null)
        {
            sphere.SetActive(true);
            float x = Random.Range(-xRange, xRange);
            float y = Random.Range(-yRange, yRange);
            sphere.transform.position = new Vector3(x, y, 0);
        }
        Invoke("SpawnSphere", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
