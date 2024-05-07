using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerUpperCatch; // ������, ������� ����� ���������� ��� �����������
    public GameObject playerLowerCatch; // ������, ������� ����� ���������� ��� �����������

    void Start()
    {
        // ��������� ��������� ��������
        playerUpperCatch.SetActive(false);
        playerLowerCatch.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // �������� playerUpperCatch � ��������� playerLowerCatch
            playerUpperCatch.SetActive(true);
            playerLowerCatch.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // �������� playerLowerCatch � ��������� playerUpperCatch
            playerLowerCatch.SetActive(true);
            playerUpperCatch.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ������������ ��������� �� 90 �������� ������
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ������������ ��������� �� 270 �������� �����
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
    }
}