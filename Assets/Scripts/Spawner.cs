using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsToSpawn;
    [SerializeField] private Transform[] spawnPoints;
    private float spawnFrequency = 2f; // ��������� ������� ������
    private float frequencyIncrease = 0.5f; // �� ������� ������������� ������� ������ ������ ���
    private float minSpawnFrequency = 0.5f; // ����������� ������� ������

    void Start()
    {       
        InvokeRepeating("SpawnPrefab", 0f, spawnFrequency);  
    }

    void SpawnPrefab()
    {     
        int randomIndex = Random.Range(0, spawnPoints.Length);    //���������� ��������� ����� ������
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        int randomPrefab = Random.Range(0, prefabsToSpawn.Length); //���������� ��������� ����
        GameObject prefab = prefabsToSpawn[randomPrefab];
        
        Instantiate(prefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        
        if (spawnFrequency > minSpawnFrequency)    //������������� ������� ������
        {
            spawnFrequency -= frequencyIncrease;
            CancelInvoke(); 
            InvokeRepeating("SpawnPrefab", 0f, spawnFrequency); 
        }
    }
}
