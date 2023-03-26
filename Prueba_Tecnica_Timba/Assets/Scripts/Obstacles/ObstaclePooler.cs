using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    private List<GameObject> objectsToPool;
    [SerializeField] private int initialAmount;
    [SerializeField] private GameObject objectToPool;


    private void Awake()
    {
        objectsToPool = new List<GameObject>();
        for(int i=0;i < initialAmount; i++)
        {
            GameObject obstacle = Instantiate(objectToPool);
            obstacle.SetActive(false);
            objectsToPool.Add(obstacle);
        }
    }

    public GameObject GetPooled()
    {
        foreach(GameObject o in objectsToPool)
        {
            if (!o.activeInHierarchy)
            {
                return o;
            }
        }
        return PoolNewObject();
    }

    public GameObject PoolNewObject()
    {
        GameObject obstacle = Instantiate(objectToPool);
        obstacle.SetActive(false);
        objectsToPool.Add(obstacle);
        return obstacle;
    }

}
