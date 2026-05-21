using UnityEngine;
using TMPro;

[RequireComponent(typeof(ScoreManager))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _scoreText.text = $"Score: {_scoreManager.Score}";
    }
}
