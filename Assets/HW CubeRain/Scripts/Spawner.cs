using UnityEngine;
using static Assets.HW_CubeRain.Scripts.SpawnEventSignalizator;


namespace Assets.HW_CubeRain.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Pool _pool;
        [SerializeField] private SpawnEventSignalizator _spawnSignal;
        [SerializeField] private Transform _bottomLeftPosition;
        [SerializeField] private Transform _topLeftPosition;
        [SerializeField] private Transform _topRightPosition;

        private void OnEnable()
        {
            _spawnSignal.SpawnAction += Spawn;
        }

        private void OnDisable()
        {
            _spawnSignal.SpawnAction -= Spawn;
        }

        public void Spawn(Vector3 transform = default)
        {
            InitializePoolObject(transform == default ? GetRandomPosition() : transform);
        }

        private Vector3 GetRandomPosition()
        {
            float randomX = Random.Range(_topLeftPosition.position.x, _topRightPosition.position.x);
            float randomZ = Random.Range(_topLeftPosition.position.z, _bottomLeftPosition.position.z);

            return new Vector3(randomX, _bottomLeftPosition.position.y, randomZ);
        }

        private void InitializePoolObject(Vector3 position)
        {
            _pool.GetObject().Initialize(position);
        }

    }
}
