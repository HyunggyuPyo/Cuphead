using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject[] pcursor;
    private int pmenuCount = 1;

    void OnEnable()
    {
        pmenuCount = 1;
    }

    void Update()
    {
        MenuSelect();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("누르긴함?");
            switch (pmenuCount)
            {
                case 1:
                    Continue();
                    break;
                case 2:
                    RePlay();
                    break;
                case 3:
                    WorldMap();
                    break;
            }
        }
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void RePlay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WorldMap()
    {
        LoadSceneController.Instance.LoadScene("World");
    }

    void MenuSelect()
    {
        if (pmenuCount != 3 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            pmenuCount++;
            CursorColor();
        }
        if (pmenuCount != 1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            pmenuCount--;
            CursorColor();
        }
    }

    void CursorColor()
    {
        switch (pmenuCount)
        {
            case 1:
                setOff();
                pcursor[1].SetActive(true);
                pcursor[2].SetActive(true);
                pcursor[4].SetActive(true);
                break;
            case 2:
                setOff();
                pcursor[3].SetActive(true);
                pcursor[0].SetActive(true);
                pcursor[4].SetActive(true);
                break;
            case 3:
                setOff();
                pcursor[5].SetActive(true);
                pcursor[0].SetActive(true);
                pcursor[2].SetActive(true);
                break;
        }
    }

    void setOff()
    {
        for (int i = 0; i < pcursor.Length; i++)
        {
            pcursor[i].SetActive(false);
        }
    }
}
