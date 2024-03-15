using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _lifeDuration;

    public void Start()
    {
        Invoke(nameof(Dispose), _lifeDuration);   
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
