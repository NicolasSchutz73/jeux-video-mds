using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameStarted;
    public event Action OnGameStopped;

    private TimeManager _timeManager;
    private RupeeManager _rupeeManager;
    private ScoreManager _scoreManager;
    
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        _timeManager = GetComponent<TimeManager>();
        _rupeeManager = GetComponent<RupeeManager>();
        _scoreManager = GetComponent<ScoreManager>();

        if (player != null)
        {
            player.SetCanMove(false);
        }
    }

    public void StartGame()
    {
        _timeManager.ResetTimer();
        _rupeeManager.ResetRupees();
        _scoreManager.ResetScore();

        if (player != null)
        {
            player.SetCanMove(true);
        }

        _timeManager.StartTimer();
        _rupeeManager.StartSpawning();

        OnGameStarted?.Invoke();
    }

    private void StopGame()
    {
        _rupeeManager.ResetRupees();

        if (player != null)
        {
            player.SetCanMove(false);
        }

        OnGameStopped?.Invoke();
    }

    private void OnEnable()
    {
        _timeManager.OnTimeUp += HandleTimeUp;
        _rupeeManager.OnRupeeCollected += HandleRupeeCollected;
    }

    private void OnDisable()
    {
        _timeManager.OnTimeUp -= HandleTimeUp;
        _rupeeManager.OnRupeeCollected -= HandleRupeeCollected;
    }

    private void HandleRupeeCollected(Rupee rupee)
    {
        _scoreManager.IncreaseScore();
    }

    private void HandleTimeUp()
    {
        StopGame();
    }
}
