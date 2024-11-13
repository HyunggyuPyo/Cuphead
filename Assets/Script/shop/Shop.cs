using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    PlayerInfo playerInfo;
    [SerializeField]
    GameObject item3;

    //[SerializeField]
    //GameObject numberSprite;
    //[SerializeField]
    //Sprite[] coinNumber;

    public GameObject puff;
    public GameObject door;
    Animator doorAni;

    public GameObject pig;
    Animator pigAni;

    void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        doorAni = door.GetComponent<Animator>();
        pigAni = pig.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pigAni.SetTrigger("goodBye");
            doorAni.SetTrigger("isExit");
            Invoke("SceneChange", 2.2f);
        }
        //CoinNumber();
    }

    void SceneChange()
    {
        LoadSceneController.Instance.LoadScene("World");
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
            puff.SetActive(true);
            pigAni.SetTrigger("buy");
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
