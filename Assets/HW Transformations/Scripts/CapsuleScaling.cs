using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScaling : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _curve;

    private float time = 0;

    void Update()
    {
        Scale();
    }

    private void Scale()
    {
        transform.localScale += new Vector3(_speed, _speed, _speed) * _curve.Evaluate(time += Time.deltaTime) * Time.deltaTime;
    }
}
