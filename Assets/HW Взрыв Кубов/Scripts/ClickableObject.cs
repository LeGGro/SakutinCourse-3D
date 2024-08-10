using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Transform), typeof(Rigidbody), typeof(Renderer))]
public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    private const string MaterialEmissionValueName = "_EmissionColor";

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private GameStarter _gameStarter;
    [SerializeField] private int _divisionChanceGrading = 2;
    [SerializeField] private float _maxDivisionChance = 100f;

    public Rigidbody Rigidbody { get; private set; }
    public int ClickGrade { get; protected set; } = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Random.Range(0, _maxDivisionChance) <= _maxDivisionChance / (Mathf.Pow(_divisionChanceGrading, ClickGrade)))
        {
            _spawner.Spawn(_spawner, _exploder, this.transform.parent.gameObject,_gameStarter, this);
        }
        else
        {
            _exploder.Explode(transform.position, ClickGrade);
        }

        _gameStarter.CheckParent();
        Destroy(gameObject);
    }

    public void Initialize(Spawner spawner, Exploder exploder,GameStarter gameStarter, int clickGrade, Color color, Vector3 scale)
    {
        GetComponent<Renderer>().material.SetColor(MaterialEmissionValueName, color);
        Rigidbody = GetComponent<Rigidbody>();
        ClickGrade = clickGrade;
        transform.localScale = scale;
        _spawner = spawner;
        _exploder = exploder;
        _gameStarter = gameStarter;
    }
}