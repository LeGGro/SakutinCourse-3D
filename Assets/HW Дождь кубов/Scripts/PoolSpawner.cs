using System.Collections;
using System.Linq;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private Transform bottomLeftPosition;
    [SerializeField] private Transform topLeftPosition;
    [SerializeField] private Transform topRightPosition;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(topLeftPosition.position.x, topRightPosition.position.x);
        float randomZ = Random.Range(topLeftPosition.position.z, bottomLeftPosition.position.z);

        return new Vector3(randomX, bottomLeftPosition.position.y, randomZ);
    }

    public void SpawnFromPool()
    {
        FallingObject.ObjPool.First().Initialize(GetRandomPosition());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            if (FallingObject.ObjPool.Count > 0)
            {
                SpawnFromPool();
                continue;
            }
        }
    }
}
