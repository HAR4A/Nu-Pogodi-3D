using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб, который вы хотите спавнить
    public Transform[] spawnPoints; // Массив точек спавна
    public float spawnFrequency = 2f; // Начальная частота спавна
    public float frequencyIncrease = 0.5f; // На сколько увеличивается частота спавна каждый раз
    public float minSpawnFrequency = 0.5f; // Минимальная частота спавна

    void Start()
    {
        // Вызываем метод SpawnPrefab с заданной частотой
        InvokeRepeating("SpawnPrefab", 0f, spawnFrequency);
    }

    void SpawnPrefab()
    {
        // Выбираем случайную точку спавна
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        // Спавним префаб в выбранной точке
        Instantiate(prefabToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // Увеличиваем частоту спавна, если она еще не достигла минимального значения
        if (spawnFrequency > minSpawnFrequency)
        {
            spawnFrequency -= frequencyIncrease;
            CancelInvoke(); // Отменяем предыдущий вызов InvokeRepeating
            InvokeRepeating("SpawnPrefab", 0f, spawnFrequency); // Запускаем новый вызов с обновленной частотой
        }
    }
}
