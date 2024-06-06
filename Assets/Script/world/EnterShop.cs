using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShop : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("보스 입장 가능");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Shop");
        }
    }
}
