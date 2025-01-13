using Assets.HW_CubeRain.Scripts.Bases;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HW_CubeRain.Scripts
{
    public class Pool<T> : SpawnEventSignalizator where T : PoolObjectBase
    {
        [SerializeField] private ConsoleInfo _consoleInfo;
        [SerializeField] private T _objectPrefab;
        [SerializeField] private Transform _objectsParent;
        [SerializeField] private float _infoUpdaterTimer;

        private PoolObjectBase _objectBase;
        private WaitForSeconds _waitForInfoUpdaterTimer;
        private int _poolUseCount = 0;
        private List<PoolObjectBase> _objects = null;
        private string _info { get => $"Объектов: {_objects.Count}\n" +
                $"Готовые к реюзу: {_objects.Where(obj=>obj.IsReady).ToList().Count}\n" +
                $"Реюзы: {_poolUseCount}"; }

        public override event SpawnActionHandler SpawnAction;


        private void Awake()
        {
            _objects = new List<PoolObjectBase>();
        }

        private void Start()
        {
            if (_consoleInfo != null)
            {
                _waitForInfoUpdaterTimer = new WaitForSeconds(_infoUpdaterTimer);
                _consoleInfo.Out(_info);
                StartCoroutine(InfoUpdating());
            }
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

            _poolUseCount++;
            return choosedObj;
        }

        private void CreateObject()
        {
            _objects.Add(Instantiate(_objectPrefab, _objectsParent));
        }

        private IEnumerator InfoUpdating()
        {
            while (true)
            {
                _consoleInfo.Out(_info);
                yield return _waitForInfoUpdaterTimer;
            }
        }
    }
}
