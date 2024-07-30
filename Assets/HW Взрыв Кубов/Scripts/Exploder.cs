using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseEplosionForce = 5f;
    [SerializeField] private float _baseExplosionRadius = 5f;

    public void Explode(Vector3 explosionPosition, int multiplier)
    {
        List<Rigidbody> explodedObjects = Physics.OverlapSphere(explosionPosition, _baseExplosionRadius * multiplier)
            .Select(collider => collider.attachedRigidbody)
            .ToList();

        foreach (var obj in explodedObjects)
        {
            obj.AddExplosionForce(_baseEplosionForce * multiplier, explosionPosition, _baseExplosionRadius * multiplier);
        }
    }
}
