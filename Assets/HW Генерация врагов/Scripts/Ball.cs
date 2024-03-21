using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _lifeDuration;
    [SerializeField] private Transform _poolCoordinates;
    
    private Rigidbody _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    public void AddDirectionalForce(Vector3 direction, float forceAmount)
    {
        _rigidbody.AddForce(direction.normalized * forceAmount, ForceMode.Impulse);
        Invoke(nameof(BackToPool), _lifeDuration);
    }

    private void BackToPool()
    {
        _rigidbody.velocity = Vector3.zero;
        transform.position = _poolCoordinates.transform.position;
    }
}
