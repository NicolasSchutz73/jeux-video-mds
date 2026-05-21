using UnityEngine;
using System.Collections;

public class RupeeSpawner : MonoBehaviour
{

    [SerializeField] private Rupee rupeePrefab;
    [SerializeField] private Transform container;
    
    [SerializeField, Range(0.1f, 5f)] 
    private float spawnDelay = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(rupeePrefab, transform.position, Quaternion.identity, container);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
