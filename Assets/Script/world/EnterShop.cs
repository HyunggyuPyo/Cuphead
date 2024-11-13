using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("보스 입장 가능");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadSceneController.Instance.LoadScene("Shop");
        }
    }
}
