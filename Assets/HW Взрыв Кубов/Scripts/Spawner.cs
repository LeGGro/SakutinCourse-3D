using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minDivisionCount = 2;
    [SerializeField] private int _maxDivisionCount = 6;
    [SerializeField] private float _scaleGrading = 2f;
    [SerializeField] private float _emissionIntensity = 5f;
    [SerializeField] private List<ClickableObject> _spawnedObj = new List<ClickableObject>();
    
    public int SpawnedObjCount { get
        { 
            return _spawnedObj.Count;
        }}

    public List<ClickableObject> Spawn(Spawner spawner, Exploder exploder, GameObject parent, GameStarter gameStarter, ClickableObject clickableObject)
    {
        int divisionDegree = Random.Range(_minDivisionCount, _maxDivisionCount);
        List<ClickableObject> devidedObject = new List<ClickableObject>();

        for (int i = 0; i < divisionDegree; i++)
        {
            devidedObject.Add(SpawnSingle(spawner, exploder, parent, gameStarter,  clickableObject));
        }

        _spawnedObj.AddRange(devidedObject);
        return devidedObject;
    }

    public ClickableObject SpawnSingle(Spawner spawner, Exploder exploder,GameObject parent,GameStarter gameStarter,   ClickableObject clickableObject)
    {
        var tempClickableObject = Instantiate(clickableObject, parent.transform);
        tempClickableObject.Initialize(spawner, exploder, gameStarter,  clickableObject.ClickGrade + 1,
            Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 0.5f) * Mathf.Pow(2f, _emissionIntensity),
            clickableObject.transform.localScale / _scaleGrading);

        return tempClickableObject;
    }

}
