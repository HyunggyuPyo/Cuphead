using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStart = true;
    public bool isGamover = false;
    public GameObject introText;
    public GameObject gameoverUI;
    public GameObject pauseUI;

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
    }
    void Start()
    {
        Invoke("IntroOff", 3.9f);
    }

    void IntroOff()
    {
        introText.SetActive(false);
    }

    void Score()
    {
        // 게임 끝나고 점수 계산 해줄 함수
    }
    
    public void PauseMenu()
    {
        Time.timeScale = 0f;
        gameoverUI.SetActive(true);
    }

    public void PlayerDead()
    {
        isGamover = true;
        gameoverUI.SetActive(true);
    }
    // 다른 스크립트에서 GameManager.instance.OnPlayerDead(); 이런식으로 호출 가능
}
