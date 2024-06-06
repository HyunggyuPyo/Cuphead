using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField]
    GameObject item3;

    void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("World");
        }
    }

    public void BuyItem1()
    {
        Debug.Log("1");
    }
    public void BuyItem2()
    {
        Debug.Log("2");
    }
    public void BuyItem3()
    {
        Debug.Log("3");
        if(PlayerInfo.Pay(3))
        {
            playerInfo.BuyWeapon(item3);
            // 버튼 이미지 변경 대충 채도 다운
        }
    }
    public void BuyItem4()
    {
        Debug.Log("4");
    }
    public void BuyItem5()
    {
        Debug.Log("5");
    }
}
