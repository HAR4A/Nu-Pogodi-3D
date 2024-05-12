using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectBrokenEgg : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlLoses;
    [SerializeField] private AudioSource brokenEgg;
    [SerializeField] private AudioSource stopChickenMusic;
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private Button musicButton;

    public static int Count;
    public bool musicOn = true;
    private bool musicPlayed = false;


    public void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            musicOn = PlayerPrefs.GetInt("Music") == 1;
        }
        UpdateButtonStates();

        if (musicOn)
        {
            stopChickenMusic.Play();
        }
        else
        {
            stopChickenMusic.Stop();
        }

        //stopChickenMusic.Play();
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

    void UpdateButtonStates()
    {
        musicButton.GetComponentInChildren<TextMeshProUGUI>().text = musicOn ? "Music ON" : "Music OFF";
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        UpdateButtonStates();

        if (!musicPlayed && musicOn)
        {
            musicPlayed = true;
            PlayerPrefs.SetInt("Music", 1);
            stopChickenMusic.Play();
        }
        else if (!musicOn) 
        {
            musicPlayed = false;
            PlayerPrefs.SetInt("Music", 0);
            stopChickenMusic.Stop();
        }
    }
}