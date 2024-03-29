using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWEnemyGeneration
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _lifeDuration;
        [SerializeField] private Rigidbody _rigidbody;

        public void Start()
        {
            Destroy(gameObject, _lifeDuration);
        }

        public void AddDirectionalForce(Vector3 direction, float forceAmount)
        {
            _rigidbody.AddForce(direction.normalized * forceAmount, ForceMode.Impulse);
        }
    }
}
