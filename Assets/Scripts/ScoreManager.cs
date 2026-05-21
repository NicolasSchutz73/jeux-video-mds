using UnityEngine;

[RequireComponent(typeof(RupeeManager))]
public class ScoreManager : MonoBehaviour
{
    private int _score;
    
    public int Score => _score;

    public void ResetScore()
    {
        _score = 0;
    }

    public void IncreaseScore()
    {
        _score += 1;
    }
}
