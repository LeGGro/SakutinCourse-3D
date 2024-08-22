using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeRain
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private int _maxPoolSize;
        [SerializeField] private Object _poolObjectPrefab;
        [SerializeField] private Transform _poolObjectsParent;

        private List<Object> _objPool = null;

        private void Awake()
        {
            _objPool = new List<Object>();
        }

        public Object GetObjectFromPool()
        {
            if (_objPool.Where(obj => obj.IsReady).Count() == 0 && _objPool.Count <= _maxPoolSize)
            {
                AddToPool();
            }

            return _objPool.First(obj => obj.IsReady == true);
        }

        private void AddToPool()
        {
            _objPool.Add(Instantiate(_poolObjectPrefab, _poolObjectsParent));
        }
    }
}
