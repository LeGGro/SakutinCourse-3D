using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _scoreText;
    [SerializeField] private TMPro.TMP_Text _recordText;

    public void SetText(string text, TextType type)
    {
        switch (type)
        {
            case TextType.Record:
                _recordText.text = text;
                break;

            case TextType.Score:
                _scoreText.text = text;
                break;
        }
    }
}

public enum TextType
{
    Record,
    Score
}
