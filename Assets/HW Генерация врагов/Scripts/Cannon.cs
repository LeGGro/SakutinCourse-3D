using System.Collections;
using UnityEngine;

namespace HWEnemyGeneration
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private float _timestep;
        [SerializeField] private Transform _outPointPosition;
        [SerializeField] private Transform _ballSpawnPosition;
        [SerializeField] private Ball _ballPrefab;
        [SerializeField] private int _forceAmount;
        [SerializeField] private Ball _currentBall;

        public void Start()
        {
            StartCoroutine(ShootRepeating());
        }

        private void Spawn()
        {
            _currentBall = Instantiate
            (_ballPrefab, _ballSpawnPosition.transform.position, _ballSpawnPosition.rotation);
        }

        private void Shoot()
        {
            Spawn();
            _currentBall.AddDirectionalForce(_outPointPosition.position - _ballSpawnPosition.position, _forceAmount);
        }

        private IEnumerator ShootRepeating()
        {
            while (true)
            {
                Shoot();
                yield return new WaitForSeconds(_timestep);
            }
        }
    }
}