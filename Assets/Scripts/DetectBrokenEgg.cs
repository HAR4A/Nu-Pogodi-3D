using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBrokenEgg : MonoBehaviour
{
    [SerializeField] private GameObject lvlLose;
    [SerializeField] private AudioSource brokenEgg;
    public static int Count;
   
    public void Start()
    {
        Count = 0;       
    }

    public void OnTriggerEnter(Collider other)
    {
        Count += 1;
        brokenEgg.GetComponent<AudioSource>().Play();

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
