using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBook : MonoBehaviour
{
    public GameObject arraw;
    Animator animator;
    private int pageCount = 0;
    private bool isTurn = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Invoke("ArrawOn", 4f);
    }

    void Update()
    {
        if(Input.anyKeyDown && !isTurn)
        {
            arraw.SetActive(false);
            isTurn = true;
            animator.SetTrigger("inputKey");
            if (pageCount == 10)
            {
                LoadSceneController.Instance.LoadScene("World");
            }
            Invoke("Delay", 2f);
            pageCount++;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadSceneController.Instance.LoadScene("World");
        }
    }

    void Delay()
    {
        arraw.SetActive(true);
        isTurn = false;
    }

    void ArrawOn()
    {
        arraw.SetActive(true);
    }
}
