using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Range(10f, 600f)] private float duration = 120f;

    public event Action OnTimeUp;
    
    public float Remaining => _remaining;

    private float _remaining;

    private bool _running;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     _remaining = duration;
     _running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_running) return;
        
        _remaining -= Time.deltaTime;

        if (_remaining <= 0f)
        {
            _remaining = 0f;
            _running = false;
            OnTimeUp?.Invoke();
        }
    }
}
