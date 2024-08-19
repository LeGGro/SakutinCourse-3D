using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private int _maxPoolSize;
    [SerializeField] private PoolObject _poolObjectPrefab;
    [SerializeField] private Transform _poolObjectsParent;

    private List<PoolObject> _objPool = null;

    private void Awake()
    {
        _objPool = new List<PoolObject>();
    }

    public PoolObject GetObjectFromPool()
    {
        if (_objPool.Where(obj=>obj.IsReady).Count() == 0 && _objPool.Count <= _maxPoolSize)
        {
            SpawnToPool();
        }

        return _objPool.First(obj=>obj.IsReady == true);
    }

    private void SpawnToPool()
    {
        _objPool.Add(Instantiate(_poolObjectPrefab, _poolObjectsParent));
    }
}
