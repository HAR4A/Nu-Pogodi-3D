using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBrokenEgg : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlLoses;
    [SerializeField] private AudioSource brokenEgg;
    [SerializeField] private AudioSource stopChickenMusic;
    [SerializeField] private AudioSource gameOver;
    public static int Count;
   
    public void Start()
    {
        Count = 0;       
    }

    public void OnTriggerEnter(Collider other)
    {
        Count += 1;
        brokenEgg.Play();

        if (Count == 5)
        {
            stopChickenMusic.Stop();
            gameOver.Play();

            foreach (GameObject lvlLose in lvlLoses)
            {
                lvlLose.SetActive(true);
               
            }
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
