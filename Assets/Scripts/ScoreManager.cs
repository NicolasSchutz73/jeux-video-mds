using UnityEngine;

[RequireComponent(typeof(RupeeManager))]
public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _bestScore;
    
    public int Score => _score;
    public int BestScore => _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt("BestScoreKey", 0);
    }
    
    public void ResetScore()
    {
        _score = 0;
    }

    public void IncreaseScore()
    {
        _score++;
        TrySaveBestScore();
    }
    
    public void TrySaveBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("BestScoreKey", _score);
            PlayerPrefs.Save();
        }
    }
}
