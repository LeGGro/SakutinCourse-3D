using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _timestep;
    [SerializeField] private Transform _outPointPosition;
    [SerializeField] private Transform _ballSpawnPosition;
    [SerializeField] private GameObject _ballSample;
    [SerializeField] private int _forceAmount;

    private GameObject _currentBall;

    public void Start()
    {
        StartCoroutine(ShootByTimestamp());
    }

    private void SpawnBall()
    {
        if (_currentBall != null)
        {
            return;
        }

        _currentBall = Instantiate(_ballSample, _ballSpawnPosition.transform.position, _ballSpawnPosition.rotation);
    }

    private void ShootBall()
    {
        Vector3 forceDirection = (_outPointPosition.transform.position - _ballSpawnPosition.transform.position).normalized;
        _currentBall.GetComponent<Rigidbody>().AddForce(forceDirection*_forceAmount, ForceMode.Impulse);
        _currentBall = null;
    }

    private IEnumerator ShootByTimestamp()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timestep) 
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _timestep)
            {
                SpawnBall();
                ShootBall();
                elapsedTime = 0f;
            }

            yield return null;
        }
    }
}
