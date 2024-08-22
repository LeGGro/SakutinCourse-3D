using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


namespace CubeRain
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Pool _spawner;
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private Transform _bottomLeftPosition;
        [SerializeField] private Transform _topLeftPosition;
        [SerializeField] private Transform _topRightPosition;

        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_spawnCooldown);
            StartCoroutine(Spawning());
        }

        private Vector3 GetRandomPosition()
        {
            float randomX = Random.Range(_topLeftPosition.position.x, _topRightPosition.position.x);
            float randomZ = Random.Range(_topLeftPosition.position.z, _bottomLeftPosition.position.z);

            return new Vector3(randomX, _bottomLeftPosition.position.y, randomZ);
        }

        public void SetToPosition()
        {
            _spawner.GetObjectFromPool().Initialize(GetRandomPosition());
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                SetToPosition();
                yield return _waitForSeconds;
            }
        }
    } 
}
