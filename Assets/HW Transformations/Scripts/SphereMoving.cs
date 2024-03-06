using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SphereMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private AnimationCurve _path;

    private float time = 0;

    void Update()
    {
        Move();
    }

    public void Move() 
    {
        transform.position += _direction.normalized * _speed * _path.Evaluate(time += Time.deltaTime);
    }
}
