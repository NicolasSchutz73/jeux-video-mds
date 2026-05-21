using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(TimeManager))]
[RequireComponent(typeof(GameManager))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI remainingText;
    [SerializeField] private GameObject startButton;

    private ScoreManager _scoreManager;
    private TimeManager _timeManager;
    private GameManager _gameManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
        _gameManager = GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        _gameManager.OnGameStarted += HandleGameStarted;
        _gameManager.OnGameStopped += HandleGameStopped;
    }

    private void OnDisable()
    {
        _gameManager.OnGameStarted -= HandleGameStarted;
        _gameManager.OnGameStopped -= HandleGameStopped;
    }

    private void Update()
    {
        scoreText.text = $"Score : {_scoreManager.Score}";
        remainingText.text = TimeSpan.FromSeconds(_timeManager.Remaining).ToString(@"mm\:ss");
    }

    private void HandleGameStarted()
    {
        startButton.SetActive(false);
    }

    private void HandleGameStopped()
    {
        startButton.SetActive(true);
    }
}