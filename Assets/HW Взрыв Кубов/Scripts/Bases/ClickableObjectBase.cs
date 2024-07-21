using UnityEngine;

[RequireComponent(typeof(Transform), typeof(Rigidbody))]
public class ClickableObjectBase : MonoBehaviour
{
    public void Initialize()
    {
        Material = GetComponent<Renderer>().material;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody Rigidbody { get; private set; }

    public Material Material{ get; protected set; }

    public int ClickGrade { get; protected set; } = 0;

    public void IncreaseClickGrade()
    {
        ClickGrade++;    
    }
}
