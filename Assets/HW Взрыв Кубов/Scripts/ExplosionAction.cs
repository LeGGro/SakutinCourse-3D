
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionAction : ClickActionBase
{
    private const string MaterialEmissionValueName = "_EmissionColor";

    [SerializeField]
    private int _minDivisionCount = 2;
    [SerializeField]
    private int _maxDivisionCount = 6;
    [SerializeField]
    private float _scaleGrading = 2f;
    [SerializeField]
    private int _divisionChanceGrading = 2;
    [SerializeField]
    private float _maxDivisionChance = 100f;
    [SerializeField]
    private float _emissionIntensity = 5f;
    [SerializeField]
    private float _explosionForce = 1f;
    [SerializeField]
    private float _explosionRadius = 1f;


    public override void Act(ClickableObjectBase clickable)
    {
        Explode(clickable);
    }

    private void Explode(ClickableObjectBase clickable)
    {
        if (Random.Range(0, _maxDivisionChance) <= _maxDivisionChance / (Mathf.Pow(_divisionChanceGrading, clickable.ClickGrade)))
        {
            int divisionDegree = Random.Range(_minDivisionCount, _maxDivisionCount);
            List<ClickableObjectBase> devidedObject = new List<ClickableObjectBase>();
            ClickableObjectBase tempClickableObject;

            for (int i = 0; i < divisionDegree; i++)
            {
                tempClickableObject = Instantiate(clickable);
                tempClickableObject.Initialize();
                tempClickableObject.transform.localScale /= _scaleGrading;
                tempClickableObject.IncreaseClickGrade();
                tempClickableObject.Material.SetColor(MaterialEmissionValueName, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 0.5f) * Mathf.Pow(2f, _emissionIntensity));

                devidedObject.Add(tempClickableObject);
                List<Rigidbody> rigidbodes = devidedObject.Select(obj => obj.Rigidbody).ToList();

                foreach (var item in rigidbodes)
                {
                    item.AddExplosionForce(_explosionForce, this.transform.position, _explosionRadius);
                }
            }
        }
       
        Destroy(clickable.gameObject);
    }
}
