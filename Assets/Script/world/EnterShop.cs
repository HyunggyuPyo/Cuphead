using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShop : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("���� ���� ����");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
