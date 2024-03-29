using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWEnemyGenerationPRO
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay;
        [SerializeField] private PathFollower _beeTarget;
        [SerializeField] private Bee _beePrefab;
        [SerializeField] private Transform _beeSpawnPoint;

        public void Start()
        {
            StartCoroutine(SpawnRepeating());
        }

        private void Spawn()
        {
            Instantiate(_beePrefab, _beeSpawnPoint.transform.position, _beeSpawnPoint.rotation).FollowTarget(_beeTarget);
        }

        private IEnumerator SpawnRepeating()
        {
            while (true)
            {
                Spawn();
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}
