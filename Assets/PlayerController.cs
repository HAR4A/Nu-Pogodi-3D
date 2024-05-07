using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerUpperCatch; // Объект, который будет включаться или выключаться
    public GameObject playerLowerCatch; // Объект, который будет включаться или выключаться

    private float initialRotationY; // Начальный угол поворота по оси Y

    void Start()
    {
        // Начальное состояние объектов
        playerUpperCatch.SetActive(false);
        playerLowerCatch.SetActive(true);

        // Сохраняем начальный угол поворота
        initialRotationY = -90;/*transform.rotation.eulerAngles.y*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Включаем playerUpperCatch и выключаем playerLowerCatch
            playerUpperCatch.SetActive(true);
            playerLowerCatch.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Включаем playerLowerCatch и выключаем playerUpperCatch
            playerLowerCatch.SetActive(true);
            playerUpperCatch.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Поворачиваем персонажа на 90 градусов вправо
            transform.rotation = Quaternion.Euler(0f, initialRotationY + 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Поворачиваем персонажа на 270 градусов влево
            transform.rotation = Quaternion.Euler(0f, initialRotationY - 90f, 0f);
        }
    }
}