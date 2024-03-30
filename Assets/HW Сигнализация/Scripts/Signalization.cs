using System.Collections;
using UnityEngine;

namespace HWSignalization
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(EnemyDetector))]

    public class Signalization : MonoBehaviour
    {
        private const float MaxVolume = 1;
        private const float MinVolume = 0;

        [SerializeField] private float _deltaStep;

        private EnemyDetector _enemyDetector;
        private AudioSource _audioSource;
        private Coroutine _currentCoroutine;

        public void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _enemyDetector = GetComponent<EnemyDetector>();
        }

        private void OnEnable()
        {
            _enemyDetector.OnEnemyEntered += StartSiren;
            _enemyDetector.OnEnemyExited += StopSiren;
        }

        private void OnDisable()
        {
            _enemyDetector.OnEnemyEntered -= StartSiren;
            _enemyDetector.OnEnemyExited -= StopSiren;
        }

        public void StartSiren()
        {
            if (_currentCoroutine != null)
            { 
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(ChangeVolumeSmoothly(MaxVolume));

        }

        public void StopSiren()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(ChangeVolumeSmoothly(MinVolume));
        }

        private IEnumerator ChangeVolumeSmoothly(float value)
        {
            while (_audioSource.volume != value)
            {
                _audioSource.volume = Mathf.Clamp01(Mathf.MoveTowards(_audioSource.volume, value, _deltaStep * Time.deltaTime));
                yield return null;
            }
        }
    }
}
