using Assets.HW_CubeRain.Scripts.Bases;
using System.Collections;
using UnityEngine;

namespace Assets.HW_CubeRain.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Renderer))]
    public class CubeObject : PoolObjectBase
    {
        [SerializeField] private float _lifetimeRangeMin = 2;
        [SerializeField] private float _lifetimeRangeMax = 5;
        [SerializeField] private Color _defaultColour = Color.white;
        private WaitForSeconds _waitForSeconds;
        private Material _material;
        private Coroutine _activeCoroutine;

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

        public override void Initialize(Vector3 position)
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
