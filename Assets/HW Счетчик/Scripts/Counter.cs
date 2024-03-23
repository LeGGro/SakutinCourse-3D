using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _valueStep;
    [SerializeField] private float _timeStep;

    private float _currentValue = 0f;
    private Coroutine _counterCoroutine = null; 

    void Start()
    {
        _text.text = "Counter\n" + _currentValue;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_counterCoroutine == null)
            {
                _counterCoroutine = StartCoroutine(DisplayCounter());
            }
            else
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private void Display()
    {
        _text.text = "Counter\n" + _currentValue;
        _currentValue += _valueStep;
    }

    private IEnumerator DisplayCounter()
    {
        while (true)
        {
            Display();
            yield return new WaitForSeconds(_timeStep);
        }
    }
}
