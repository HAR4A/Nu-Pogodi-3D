using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void RestartGame()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;               
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);     //перезагрузка текущей сцены
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
