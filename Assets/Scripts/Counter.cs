using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CounterText;
    [SerializeField] private TextMeshProUGUI RecordText;
    [SerializeField] private AudioSource catchEgg;
    private static int sharedCount = 0;
    private int topScore;
    private const string HighScoreKey = "HighScore";

    

    private void Start()
    {
        sharedCount = 0;
        topScore = PlayerPrefs.GetInt(HighScoreKey, 0);      
        UpdateTopScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject)
        {
            catchEgg.Play();
            sharedCount++; 
            UpdateCounterText(); 
            Destroy(other.gameObject);
            CheckForNewTopScore();
        }
    }

    private void UpdateCounterText()
    {
        CounterText.text = "EGGS: " + sharedCount;
    }


    private void CheckForNewTopScore()
    {
        if (sharedCount > topScore)
        {
            topScore = sharedCount;
            PlayerPrefs.SetInt(HighScoreKey, topScore);
            UpdateTopScoreText();
        }
    }
    private void UpdateTopScoreText()
    {
        RecordText.text = "TOP: " + topScore;
    }
}