using Assets.HW_Дождь_кубов.Scripts.Bases;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.HW_Дождь_кубов.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Renderer))]
    public class ExplosingBomb : PoolObjectBase
    {
        [SerializeField] private float _lifetimeRangeMin = 2;
        [SerializeField] private float _lifetimeRangeMax = 5;
        [SerializeField] private float _explosionRadius = 5;
        [SerializeField] private float _eplosionForce = 5f;
        [SerializeField] private Color _defaultColour = Color.black;

        private float _lifetimeSeconds;
        private Material _material;
        private Coroutine _activeCoroutine;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        public override void Initialize(Vector3 position)
        {
            IsReady = false;
            _material.color = _defaultColour;
            transform.position = position;

            if (_activeCoroutine == null)
            {
                _lifetimeSeconds = Random.Range(_lifetimeRangeMin, _lifetimeRangeMax);
                _activeCoroutine = StartCoroutine(LifetimeCountdown());
            }
        }

        private IEnumerator LifetimeCountdown()
        {
            float timer = 0.0f;

            while (_lifetimeSeconds > timer)
            {
                _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.Lerp(1, 0, timer / _lifetimeSeconds));

                timer += Time.deltaTime;
                yield return null;
            }

            List<Rigidbody> explodedObjects = Physics.OverlapSphere(transform.position, _explosionRadius)
                            .Select(collider => collider.attachedRigidbody)
                            .ToList();

            foreach (var obj in explodedObjects)
            {
                obj.AddExplosionForce(_eplosionForce, transform.position, _explosionRadius);
            }

            IsReady = true;
            _activeCoroutine = null;
        }
    }
}
