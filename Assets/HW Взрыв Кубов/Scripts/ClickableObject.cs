using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Transform), typeof(Rigidbody), typeof(Renderer))]
public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    private const string MaterialEmissionValueName = "_EmissionColor";

    public Rigidbody Rigidbody { get; private set; }
    public int ClickGrade { get; protected set; } = 0;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _divisionChanceGrading = 2;
    [SerializeField] private float _maxDivisionChance = 100f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Random.Range(0, _maxDivisionChance) <= _maxDivisionChance / (Mathf.Pow(_divisionChanceGrading, ClickGrade)))
        {
            _exploder.Explode(_spawner.Spawn(this), this.transform.position);
        }

        Destroy(this.gameObject);
    }

    public void Initialize(int clickGrade, Color color, Vector3 scale)
    {
        GetComponent<Renderer>().material.SetColor(MaterialEmissionValueName, color);
        Rigidbody = GetComponent<Rigidbody>();
        ClickGrade = clickGrade;
        transform.localScale = scale;
    }
}