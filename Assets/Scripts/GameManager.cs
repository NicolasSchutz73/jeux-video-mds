using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimeManager _timeManager;
    private RupeeManager _rupeeManager;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _timeManager = GetComponent<TimeManager>();
        _rupeeManager = GetComponent<RupeeManager>();
        _scoreManager = GetComponent<ScoreManager>();
    }
    
    private void OnEnable()
    {
        _timeManager.OnTimeUp += HandleTimeUp;
        _rupeeManager.OnRupeeCollected += handleRupeeCollected;
    }

    private void OnDisable()
    {
        _timeManager.OnTimeUp -= HandleTimeUp;
        _rupeeManager.OnRupeeCollected -= handleRupeeCollected;
    }

    private void handleRupeeCollected(Rupee rupee)
    {
        _scoreManager.IncreaseScore();
    }

    private void HandleTimeUp()
    {
        _rupeeManager.StopSpawning();
    }
}
