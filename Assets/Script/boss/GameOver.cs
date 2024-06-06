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
        //SceneManager.LoadScene(0);
        // Time.timeScale = 1f;
        Debug.Log("월드맵 이동");
        gameObject.SetActive(false);
    }

    public void Exit()
    {

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
