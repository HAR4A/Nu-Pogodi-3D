using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 90f; // Скорость поворота

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Поворачиваем персонажа на 90 градусов вправо
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Поворачиваем персонажа на 270 градусов влево
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
    }
}
