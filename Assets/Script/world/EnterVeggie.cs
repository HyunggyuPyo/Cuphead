using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterVeggie : MonoBehaviour
{
    //[SerializeField]
    //GameObject enterUI;

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("���� ���� ����");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Veggie");
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    // �̰� �÷��̾� �ڵ忡 �־�� �� 
    //    enterUI.SetActive(false);
    //}
}
