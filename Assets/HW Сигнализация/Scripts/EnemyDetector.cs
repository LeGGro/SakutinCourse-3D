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
        public event Action EnemyEntered;
        public event Action EnemyExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HWEnemyGenerationPRO.PathFollower enemy))
            {
                EnemyEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HWEnemyGenerationPRO.PathFollower enemy))
            {
                EnemyExited?.Invoke();
            }
        }
    }
}
