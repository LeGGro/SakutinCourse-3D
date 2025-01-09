using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleInfo : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private string _title;
    [SerializeField] private string _body;

    private string _finalText { get => _title + "\n" + _body;  }

    private void OnValidate()
    {
        _text.text = _finalText;
    }

    public void Initialize(string body, string title)
    {
        _body = body;
        _title = title;
        _text.text = _finalText;
    }

    public void Out(string body)
    {
        _body = body;
        _text.text = _finalText;
    }
}
