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

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
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
