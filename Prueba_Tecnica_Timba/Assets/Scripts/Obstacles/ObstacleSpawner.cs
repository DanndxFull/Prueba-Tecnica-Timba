using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 timeToSpawnRange;
    [SerializeField] private ObstaclePooler pooler;
    private GameObject newObstacle;

    private float currentTime, timeToSpawn;

    private void Start()
    {
        currentTime = 0;
        timeToSpawn = Random.Range(timeToSpawnRange.x, timeToSpawnRange.y);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToSpawn)
        {
            timeToSpawn = Random.Range(timeToSpawnRange.x, timeToSpawnRange.y);
            currentTime = 0;
            newObstacle = pooler.GetPooled();
            newObstacle.transform.position = transform.position;
            newObstacle.transform.rotation = transform.rotation;
            newObstacle.SetActive(true);
        }
    }

}
