using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void RestartGame()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        
        // Перезагружаем текущую сцену
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
    }
}
