using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _timestep;
    [SerializeField] private Transform _outPointPosition;
    [SerializeField] private Transform _ballSpawnPosition;
    [SerializeField] private Ball _ballSample;
    [SerializeField] private int _forceAmount;
    [SerializeField] private List<Ball> _ballPool;
    [SerializeField] private Ball _currentBall;

    public void Start()
    {
        StartCoroutine(ShootRepeating());
    }

    private void Spawn()
    {
        _currentBall = Instantiate
            (
            _ballSample.gameObject, 
            _ballSpawnPosition.transform.position,
            _ballSpawnPosition.rotation
            ).GetComponent<Ball>();
    }

    public void LoadBall()
    {
        _currentBall.transform.position = _ballSpawnPosition.position;
    }

    private void PullBall()
    {
        _currentBall = _ballPool.First();
        _ballPool.Add(_currentBall);
        _ballPool.RemoveAt(0);
    }

    private void Shoot()
    {
        PullBall();
        LoadBall();
        _currentBall.AddDirectionalForce(_outPointPosition.position - _ballSpawnPosition.position, _forceAmount);
    }

    private IEnumerator ShootRepeating()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timestep) 
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _timestep)
            {
                Shoot();
                elapsedTime = 0f;
            }

            yield return null;
        }
    }
}
