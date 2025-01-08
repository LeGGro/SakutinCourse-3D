using Assets.HW_Дождь_кубов.Scripts.Bases;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HW_Дождь_кубов.Scripts
{
    public class Pool : SpawnEventSignalizator
    {
        [SerializeField] private PoolObjectBase _objectPrefab;
        [SerializeField] private Transform _objectsParent;

        private List<PoolObjectBase> _objects = null;

        public override event SpawnActionHandler SpawnAction;

        private void Awake()
        {
            _objects = new List<PoolObjectBase>();
        }

        public PoolObjectBase GetObject()
        {
            bool isCreated = false;

            if (_objects.Where(obj => obj.IsReady).Count() == 0)
            {
                CreateObject();
                isCreated = true;
            }

            PoolObjectBase choosedObj = _objects.First(obj => obj.IsReady == true);

            if (!isCreated)
                SpawnAction?.Invoke(choosedObj.transform.position);

            return choosedObj;
        }

        private void CreateObject()
        {
            _objects.Add(Instantiate(_objectPrefab, _objectsParent));
        }
    }
}
