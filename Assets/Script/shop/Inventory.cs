using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject main;
    GameObject weaponA;
    GameObject weaponB;

    private bool onInventory = false;

    void Awake()
    {
        main = transform.GetChild(0).gameObject;
        weaponA = transform.GetChild(1).gameObject;
        weaponB = transform.GetChild(2).gameObject;
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
                main.SetActive(false);
                weaponA.SetActive(false);
                weaponB.SetActive(false);
                onInventory = false;
            }
            else
            {
                main.SetActive(true);
                onInventory = true;
            }
        }
    }
}
