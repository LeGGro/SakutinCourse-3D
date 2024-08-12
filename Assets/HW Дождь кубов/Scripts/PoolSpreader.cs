using System.Collections;
using System.Linq;
using UnityEngine;

public class PoolSpreader : MonoBehaviour
{
    [SerializeField] private Transform _bottomLeftPosition;
    [SerializeField] private Transform _topLeftPosition;
    [SerializeField] private Transform _topRightPosition;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(_topLeftPosition.position.x, _topRightPosition.position.x);
        float randomZ = Random.Range(_topLeftPosition.position.z, _bottomLeftPosition.position.z);

        return new Vector3(randomX, _bottomLeftPosition.position.y, randomZ);
    }

    public void SpawnFromPool()
    {
        PoolObject.ObjPool.First().Initialize(GetRandomPosition());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            if (PoolObject.ObjPool.Count > 0)
            {
                SpawnFromPool();
            }

            yield return null;
        }
    }
}
