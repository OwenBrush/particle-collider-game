using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] ObjectPool spherePool;
    [SerializeField] Paddle paddle;

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    [SerializeField] float xRange;
    [SerializeField] float yRange;

    [SerializeField] float nextSpawn;

    private void Start()
    {
        spherePool = GetComponent<ObjectPool>();
        nextSpawn = maxSpawnTime;
    }

    private void Update()
    {
        if (paddle.gameRunning)
        {
            nextSpawn -= Time.deltaTime;
            if (nextSpawn <= 0)
            {
                SpawnSphere();
                nextSpawn += Random.Range(minSpawnTime, maxSpawnTime);
            }
        }
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
    }
}
