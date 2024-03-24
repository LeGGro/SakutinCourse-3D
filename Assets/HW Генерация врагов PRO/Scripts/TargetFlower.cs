using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEditor.UIElements;
using UnityEngine;

public class TargetFlower : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoints;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _pathSample;

    private int _currentTargetIndex;

    public void Start()
    {
        StartCoroutine(MovePathRepeating());
    }

    private IEnumerator MovePathRepeating()
    {
        while (true) 
        {
            transform.Translate((_pathPoints[_currentTargetIndex].transform.position - transform.position).normalized * _speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _pathSample.tag)
        {
            ChangePathPoint();
        }
    }

    private void ChangePathPoint()
    {
        _currentTargetIndex = (_currentTargetIndex + 1) % _pathPoints.Count;
    }
}
