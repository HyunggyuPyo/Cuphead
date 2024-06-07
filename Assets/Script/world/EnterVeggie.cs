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
        Debug.Log("보스 입장 가능");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Veggie");
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    // 이건 플레이어 코드에 넣어야 함 
    //    enterUI.SetActive(false);
    //}
}
