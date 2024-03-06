using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        Rotate();
        Scale();
        Move();
    }

    private void Scale()
    {
        transform.localScale += new Vector3(_scaleSpeed, _scaleSpeed, _scaleSpeed) * Time.deltaTime;
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, _rotateSpeed, 0));
    }

    public void Move()
    {
        transform.position += transform.forward.normalized * _moveSpeed * Time.deltaTime;
    }
}
