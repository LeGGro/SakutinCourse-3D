using System.Collections;
using UnityEngine;

namespace CubeRain
{
    [RequireComponent(typeof(Rigidbody), typeof(Renderer))]
    public class Object : MonoBehaviour
    {
        [SerializeField] private float _lifetimeRangeMin = 2;
        [SerializeField] private float _lifetimeRangeMax = 5;
        [SerializeField] private Color _defaultColour = Color.white;
        private WaitForSeconds _waitForSeconds;
        private Material _material;
        private Coroutine _activeCoroutine;

        public bool IsReady { get; private set; } = true;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Floor>(out _))
            {
                if (_activeCoroutine == null)
                {
                    _material.color = Random.ColorHSV();
                    _waitForSeconds = new WaitForSeconds(Random.Range(_lifetimeRangeMin, _lifetimeRangeMax));
                    _activeCoroutine = StartCoroutine(LifetimeCountdown());
                }
            }
        }

        public void Initialize(Vector3 position)
        {
            IsReady = false;
            _material.color = _defaultColour;
            transform.position = position;
        }

        private IEnumerator LifetimeCountdown()
        {
            yield return _waitForSeconds;
            IsReady = true;
            _activeCoroutine = null;
        }
    }
}
