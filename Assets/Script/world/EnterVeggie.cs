using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVeggie : MonoBehaviour
{
    //[SerializeField]
    //GameObject enterUI;

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("보스 입장 가능");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadSceneController.Instance.LoadScene("Veggie");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("보스 입장 가능");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadSceneController.Instance.LoadScene("Veggie");
        }
    }
}
