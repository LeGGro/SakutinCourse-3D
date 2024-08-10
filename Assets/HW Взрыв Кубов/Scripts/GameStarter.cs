using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private ClickableObject _startObj;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private string _startScoreText = "Score: 0";
    [SerializeField] private float _startDelay = 5f;

    public void Awake()
    {
        StartGame();
    }

    public void CheckParent()
    {
        if (_parent.transform.childCount == 0)
            Invoke(nameof(StartGame), _startDelay);
    }

    private void StartGame()
    {
        _scoreCounter.SetText(_startScoreText, TextType.Score);
        _spawner.SpawnSingle(_spawner, _exploder, _parent, this, _startObj);
    }
}
