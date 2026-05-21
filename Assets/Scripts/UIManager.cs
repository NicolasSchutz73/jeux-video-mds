using UnityEngine;
using TMPro;

[RequireComponent(typeof(ScoreManager))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;
    
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _scoreText.text = $"Score: {_scoreManager.Score}";
        _timeText.text = $"Temps: {_timeManager.Remaining:F1}";
    }
}
