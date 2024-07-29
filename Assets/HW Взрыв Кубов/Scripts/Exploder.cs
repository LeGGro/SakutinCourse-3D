using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1f;
    [SerializeField] private float _explosionRadius = 1f;

    public void Explode(List<ClickableObject> clickableObjects, Vector3 explosionPosition)
    {
        foreach (var obj in clickableObjects)
        {
            obj.Rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }
}
