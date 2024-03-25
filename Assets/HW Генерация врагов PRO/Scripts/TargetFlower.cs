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
    [SerializeField] private float _closeRange;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _pathSample;

    private int _currentTargetIndex;

    public void Start()
    {
        StartCoroutine(PathMoving());
    }

    private IEnumerator PathMoving()
    {
        while (true) 
        {
            if (IsCloseUp())
            {
                ChangePathPoint();
            }

            transform.Translate((_pathPoints[_currentTargetIndex].transform.position - transform.position).normalized * _speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private bool IsCloseUp()
    {
        if ((transform.position - _pathPoints[_currentTargetIndex].position).magnitude <= _closeRange)
        {
            return true;
        }

        return false;
    }

    private void ChangePathPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _pathPoints.Count;
    }
}
