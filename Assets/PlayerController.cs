using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 90f; // �������� ��������

    void Update()
    {
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
