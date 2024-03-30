using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace HWSignalization
{
    [RequireComponent(typeof(Collider))]

    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] public event Action OnEnemyEntered;
        [SerializeField] public event Action OnEnemyExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HWEnemyGenerationPRO.PathFollower enemy))
            {
                OnEnemyEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HWEnemyGenerationPRO.PathFollower enemy))
            {
                OnEnemyExited?.Invoke();
            }
        }
    }
}
