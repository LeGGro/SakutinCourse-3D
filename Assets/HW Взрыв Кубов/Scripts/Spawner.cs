using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minDivisionCount = 2;
    [SerializeField] private int _maxDivisionCount = 6;
    [SerializeField] private float _scaleGrading = 2f;
    [SerializeField] private float _emissionIntensity = 5f;

    public List<ClickableObject> Spawn(ClickableObject clickableObject)
    {
        int divisionDegree = Random.Range(_minDivisionCount, _maxDivisionCount);
        List<ClickableObject> devidedObject = new List<ClickableObject>();
        ClickableObject tempClickableObject;

        for (int i = 0; i < divisionDegree; i++)
        {
            tempClickableObject = Instantiate(clickableObject);
            tempClickableObject.Initialize(clickableObject.ClickGrade + 1,
                Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 0.5f) * Mathf.Pow(2f, _emissionIntensity),
                clickableObject.transform.localScale / _scaleGrading);

            devidedObject.Add(tempClickableObject);
        }

        return devidedObject;
    }
}
