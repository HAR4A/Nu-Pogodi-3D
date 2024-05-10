using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBrokenEgg : MonoBehaviour
{
    [SerializeField] private GameObject lvlLose;
    private int Count = 0;


    private void Start()
    {
        Count = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        Count += 1;

        if (Count == 5)
        {
            lvlLose.SetActive(true);
        }

        if (other.gameObject)
        {
            Destroy(other.gameObject);
        }
    }
}
