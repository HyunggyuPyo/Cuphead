using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject mainUI;
    GameObject weaponAUI;
    GameObject weaponBUI;
    //public GameObject playerWeapon;
    WPlayerMove  wPlayerMove;
    private bool onInventory = false;

    void Awake()
    {
        mainUI = transform.GetChild(0).gameObject;
        weaponAUI = transform.GetChild(1).gameObject;
        weaponBUI = transform.GetChild(2).gameObject;
        wPlayerMove = FindObjectOfType<WPlayerMove>();
    }

    void Update()
    {
        MainOpen();
    }

    void MainOpen()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (onInventory)
            {
                //wPlayerMove.CanMove();
                mainUI.SetActive(false);
                weaponAUI.SetActive(false);
                weaponBUI.SetActive(false);
                onInventory = false;
            }
            else
            {
                //wPlayerMove.CantMove();
                mainUI.SetActive(true);
                onInventory = true;
            }
        }
    }
}
