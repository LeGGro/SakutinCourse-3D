using Assets.HW_Дождь_кубов.Scripts;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.HW_Дождь_кубов.Scripts
{
    public class SpawnTimer : SpawnEventSignalizator
    {
        [SerializeField] private float _cooldown;
        private WaitForSeconds _waitForSeconds;

        public override event SpawnActionHandler SpawnAction;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_cooldown);
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                SpawnAction?.Invoke();
                yield return _waitForSeconds;
            }
        }
    }
}
