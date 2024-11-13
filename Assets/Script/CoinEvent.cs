using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEvent : MonoBehaviour
{
    Animator eventAni;
    private bool exit = false;

    void Awake()
    {
        eventAni = GetComponent<Animator>();
    }

    void Start()
    {
        Invoke("cantExit", 2f);
    }

    void Update()
    {
        if(exit && Input.GetKeyDown(KeyCode.Z))
        {
            eventAni.SetTrigger("fadeOut");
            PlayerInfo.BonusCoin();
            Invoke("FadeOut", 3f);
        }
    }

    void FadeOut()
    {
        gameObject.SetActive(false);
    }

    void cantExit()
    {
        exit = true;
    }
}
