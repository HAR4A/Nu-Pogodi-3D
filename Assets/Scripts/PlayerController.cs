using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerUpperCatch;
    [SerializeField] private GameObject playerLowerCatch;

    private float rotationAngle = -90f;

    void Start()
    {       
        playerUpperCatch.SetActive(false);
        playerLowerCatch.SetActive(true);

        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);   //начальный угол поворота
    }

    void Update()
    {
        // Повороты право, лево
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotationAngle = 90f;  // Правый поворот
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotationAngle = -90f;  // Левый поворот
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }

        // Верх, низ
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpArrow_EnableUpper();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownArrow_ReturnLower();
        }
    }

    // верхняя стрелка и включение верхних рук
    void UpArrow_EnableUpper()
    {
        playerLowerCatch.SetActive(false);
        playerUpperCatch.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        playerUpperCatch.SetActive(true);
    }

    // нижняя стрелка и включение нижних рук
    void DownArrow_ReturnLower()
    {
        playerUpperCatch.SetActive(false);
        playerLowerCatch.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        playerLowerCatch.SetActive(true);
    }
}