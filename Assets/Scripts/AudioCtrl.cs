using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioCtrl : MonoBehaviour
{
    public bool musicOn = true;
  //  public bool soundOn = true;

    [SerializeField] private Button musicButton;
  //  [SerializeField] private Button soundButton;

    void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            musicOn = PlayerPrefs.GetInt("Music") == 1;
        }
       /* if (PlayerPrefs.HasKey("Sound"))
        {
            soundOn = PlayerPrefs.GetInt("Sound") == 1;
        }*/

        UpdateButtonStates();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("Music", musicOn ? 1 : 0);
        UpdateButtonStates();
    }

    /*public void ToggleSound()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetInt("Sound", soundOn ? 1 : 0);
        UpdateButtonStates();
    }*/

    void UpdateButtonStates()
    {
        musicButton.GetComponentInChildren<TextMeshProUGUI>().text = musicOn ? "Music ON" : "Music OFF";
      //  soundButton.GetComponentInChildren<TextMeshProUGUI>().text = soundOn ? "Sound ON" : "Sound OFF";
    }
}

