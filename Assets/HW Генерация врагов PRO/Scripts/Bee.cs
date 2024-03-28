using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PathFollower _targetFlower;

    public void FollowTarget(PathFollower targetFlower)
    {
        _targetFlower = targetFlower;
        StartCoroutine(Following());
    }

    public IEnumerator Following() 
    {
        while (true) 
        {
            transform.LookAt(_targetFlower.transform);
            transform.Translate((_targetFlower.transform.position - transform.position).normalized * _speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}
