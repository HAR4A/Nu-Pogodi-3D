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
        // Начальное состояние объектов
        playerUpperCatch.SetActive(false);
        playerLowerCatch.SetActive(true);

        // Сохраняем начальный угол поворота
        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
    }

    void Update()
    {
        //повороты право, лево

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {            
            rotationAngle = 90f;  //right rotation
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {            
            rotationAngle = -90f;  //left rotation
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }

        //верх низ
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpArrow_EnableUpper();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownArrow_ReturnLower();
        }

        //ВЕРХНЯЯ СТРЕЛКА И ВКЛЮЧЕНИЕ ВЕРХНИХ РУК
        void UpArrow_EnableUpper()
        {
            if (rotationAngle == -90f)  //-90
            {
                playerLowerCatch.SetActive(false);
                rotationAngle = -90f;
                playerUpperCatch.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                playerUpperCatch.SetActive(true);
            }
            
            if (rotationAngle == 90f)  //90
            {
                playerLowerCatch.SetActive(false);
                rotationAngle = 90f;
                playerUpperCatch.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                playerUpperCatch.SetActive(true);                
            }
       
        }
       

        //НИЖНЯЯ СТРЕЛКА И ВОЗВРАТ НИЖНИХ РУК
        void DownArrow_ReturnLower() 
        {
            if (rotationAngle == -90f)
            {   
                if (playerUpperCatch.transform.rotation == Quaternion.Euler(0f, -90f, 0f))
                {
                    playerLowerCatch.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                }

                playerUpperCatch.SetActive(false);
                rotationAngle = -90f;
                playerUpperCatch.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                playerLowerCatch.SetActive(true);
            }

            if (rotationAngle == 90f)
            {
                if (playerUpperCatch.transform.rotation == Quaternion.Euler(0f, 90f, 0f))
                {
                    playerLowerCatch.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                }
                playerUpperCatch.SetActive(false);
                rotationAngle = 90f;
                playerUpperCatch.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                playerLowerCatch.SetActive(true);
            }
        }

        
    }

}

