using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsToSpawn;
    [SerializeField] private Transform[] spawnPoints;
    private float spawnFrequency = 2f; // начальная частота спавна
    private float frequencyIncrease = 0.5f; // на сколько увеличивается частота спавна каждый раз
    private float minSpawnFrequency = 0.5f; // минимальная частота спавна

    void Start()
    {       
        InvokeRepeating("SpawnPrefab", 0f, spawnFrequency);  
    }

    void SpawnPrefab()
    {     
        int randomIndex = Random.Range(0, spawnPoints.Length);    //выбирается случайная точка спавна
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        int randomPrefab = Random.Range(0, prefabsToSpawn.Length); //выбирается случайное яйцо
        GameObject prefab = prefabsToSpawn[randomPrefab];
        
        Instantiate(prefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        
        if (spawnFrequency > minSpawnFrequency)    //увеличивается частота спавна
        {
            spawnFrequency -= frequencyIncrease;
            CancelInvoke(); 
            InvokeRepeating("SpawnPrefab", 0f, spawnFrequency); 
        }
    }
}
