using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace HWTransformations
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.localScale += Vector3.one * _speed * Time.deltaTime;
        }
    }
}