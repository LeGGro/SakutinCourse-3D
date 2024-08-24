using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeRain
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private Object _objectPrefab;
        [SerializeField] private Transform _objectsParent;

        private List<Object> _objects = null;

        private void Awake()
        {
            _objects = new List<Object>();
        }

        public Object GetObject()
        {
            if (_objects.Where(obj => obj.IsReady).Count() == 0)
            {
                CreateObject();
            }

            return _objects.First(obj => obj.IsReady == true);
        }

        private void CreateObject()
        {
            _objects.Add(Instantiate(_objectPrefab, _objectsParent));
        }
    }
}
