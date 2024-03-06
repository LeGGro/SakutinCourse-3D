using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotating : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, _speed, 0));
    }
}
