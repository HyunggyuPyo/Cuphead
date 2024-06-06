using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public bool gameStart = true;
   
    public GameObject introText;
    public GameObject gameoverUI;
    public GameObject pauseUI;
    public GameObject panel;
    public GameObject dieText;
    public GameObject screenChange;

    public bool potatoDead = false;
    public bool onionDead = false;
    public bool carrotoDead = false;

    //private int BossHealth = 1235; // potato: 360 , onion: 400 , carrot: 475
    Potato potato;
    Onion onion;
    Carrot carrot;
    //Player player;
    public bool isGamover = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;

        potato = FindObjectOfType<Potato>();
        onion = FindObjectOfType<Onion>();
        carrot = FindObjectOfType<Carrot>();
        //player = FindObjectOfType<Player>();
    }

    void Start()
    {
        
    }


    void Score()
    {
        // ���� ������ ���� ��� ���� �Լ�
    }
    
    public void PauseMenu()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        pauseUI.SetActive(true);
    }

    public void PlayerDead()
    {
        panel.SetActive(true);
        dieText.SetActive(true);
        isGamover = true;
        //BossStop();
        Invoke("GameOverUI", 1f);
    }

    void GameOverUI()
    {
        Debug.Log("ī�� ��");
        gameoverUI.SetActive(true);
    }
    // �ٸ� ��ũ��Ʈ���� GameManager.instance.OnPlayerDead(); �̷������� ȣ�� ����

    //void BossStop()
    //{
    //    if(potatoDead == false)
    //    {
    //        potato.GameOver();
    //    }
    //    else if(onionDead == false)
    //    {
    //        onion.GameOver();
    //    }
    //    else
    //    {
    //        carrot.GameOver();
    //    }
    //}

    public void GameClear()
    {
        screenChange.SetActive(true);
    }
}
