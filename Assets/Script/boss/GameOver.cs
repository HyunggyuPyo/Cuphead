using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject[] cursor;
    private int menuCount = 1;

    void OnEnable()
    {
        menuCount = 1;
    }

    void Update()
    {
        MenuSelect();

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("누르긴함?");
            switch(menuCount)
            {
                case 1:
                    ReStart();
                    break;
                case 2:
                    ReturnWorld();
                    break;
                case 3:
                    Exit();
                    break;
            }
        }
    }

    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("다시 시도");
        //gameObject.SetActive(false);
    }

    public void ReturnWorld()
    {
        LoadSceneController.Instance.LoadScene("World");
        // Time.timeScale = 1f;
        Debug.Log("월드맵 이동");
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        //Time.timeScale = 1f;
        Debug.Log("게임 종료");
        gameObject.SetActive(false);
    }

    void MenuSelect()
    {
        if(menuCount != 3 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuCount++;
            CursorColor();
        }
        if (menuCount != 1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuCount--;
            CursorColor();
        }
    }
    
    void CursorColor()
    {
        switch (menuCount)
        {
            case 1:
                setOff();
                cursor[1].SetActive(true);
                cursor[2].SetActive(true);
                cursor[4].SetActive(true);
                break;
            case 2:
                setOff();
                cursor[3].SetActive(true);
                cursor[0].SetActive(true);
                cursor[4].SetActive(true);
                break;
            case 3:
                setOff();
                cursor[5].SetActive(true);
                cursor[0].SetActive(true);
                cursor[2].SetActive(true);
                break;
        }
    }

    void setOff()
    {
        for (int i = 0; i < cursor.Length; i++)
        {
            cursor[i].SetActive(false);
        }
    }

}
