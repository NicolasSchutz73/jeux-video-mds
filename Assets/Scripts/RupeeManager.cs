using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private Rupee rupeePrefab;
    [SerializeField] private Transform container;
    [SerializeField, Range(0.1f, 5f)] private float spawnDelay = 1f;
    
    public event Action<Rupee> OnRupeeCollected;

    private readonly List<Rupee> _rupees = new();
    private Coroutine _spawnRoutine;

    public void ResetRupees()
    {
        StopSpawning();
        foreach (var rupee in _rupees)
        {
            if (rupee != null) Destroy(rupee.gameObject);
        }
        _rupees.Clear();
    }
    
    public void StartSpawning()
    {
        if (_spawnRoutine != null) return;
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }
    
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        var rupee = Instantiate(rupeePrefab, spawner.position, Quaternion.identity, container);
        AddRupee(rupee);
    }

    private void AddRupee(Rupee rupee)
    {
        _rupees.Add(rupee);
        rupee.OnCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        _rupees.Remove(rupee);
        rupee.OnCollected -= RupeeCollectedHandler;
        OnRupeeCollected?.Invoke(rupee);
    }
}
