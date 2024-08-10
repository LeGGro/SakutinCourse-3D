using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class FallingObject : MonoBehaviour
{
    [SerializeField] private float _lifetimeRangeMin  = 2;
    [SerializeField] private float _lifetimeRangeMax = 5;
    private WaitForSeconds _waitForSeconds;
    private Material _material;
    private Coroutine _activeCoroutine;

    public static List<FallingObject> ObjPool { get; private set; } = null;

    private void Awake()
    {
        ObjPool ??= new List<FallingObject>();
        _waitForSeconds = new WaitForSeconds(Random.Range(_lifetimeRangeMin, _lifetimeRangeMax));
        _material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Floor>(out _))
        {
            if (_activeCoroutine == null)
            {
                _material.color = Random.ColorHSV();
                _waitForSeconds = new WaitForSeconds(Random.Range(_lifetimeRangeMin, _lifetimeRangeMax));
                _activeCoroutine = StartCoroutine(LifetimeCountdown());
            }
        }
    }

    public void Initialize(Vector3 position)
    {
        ObjPool.Remove(this);
        transform.position = position;
    }

    private IEnumerator LifetimeCountdown()
    {
        yield return _waitForSeconds;
        ObjPool.Add(this);
        _activeCoroutine = null;
    }
}
