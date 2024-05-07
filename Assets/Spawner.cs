using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������, ������� �� ������ ��������
    public Transform[] spawnPoints; // ������ ����� ������
    public float spawnFrequency = 2f; // ��������� ������� ������
    public float frequencyIncrease = 0.5f; // �� ������� ������������� ������� ������ ������ ���
    public float minSpawnFrequency = 0.5f; // ����������� ������� ������

    void Start()
    {
        // �������� ����� SpawnPrefab � �������� ��������
        InvokeRepeating("SpawnPrefab", 0f, spawnFrequency);
    }

    void SpawnPrefab()
    {
        // �������� ��������� ����� ������
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        // ������� ������ � ��������� �����
        Instantiate(prefabToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // ����������� ������� ������, ���� ��� ��� �� �������� ������������ ��������
        if (spawnFrequency > minSpawnFrequency)
        {
            spawnFrequency -= frequencyIncrease;
            CancelInvoke(); // �������� ���������� ����� InvokeRepeating
            InvokeRepeating("SpawnPrefab", 0f, spawnFrequency); // ��������� ����� ����� � ����������� ��������
        }
    }
}
