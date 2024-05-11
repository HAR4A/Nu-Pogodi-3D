using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBrokenEgg : MonoBehaviour
{
    [SerializeField] private GameObject lvlLose;   
    public static int Count;
   
    public void Start()
    {
        Count = 0;       
    }

    public void OnTriggerEnter(Collider other)
    {
        Count += 1;

        if (Count >= 5)
        {
            lvlLose.SetActive(true);
            Spawner spawner = FindObjectOfType<Spawner>();
            if (spawner != null)
            {
                spawner.StopSpawning();
            }
        }

        if (other.gameObject)
        {
            Destroy(other.gameObject);
        }
    }
}
