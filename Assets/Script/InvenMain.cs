using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenMain : MonoBehaviour
{
    [SerializeField]
    GameObject normalWeapon;
    [SerializeField]
    GameObject weaponAUI;
    [SerializeField]
    GameObject weaponBUI;
    [SerializeField]
    Image weaponASprite;
    [SerializeField]
    Image weaponBSprite;

    [HideInInspector]
    public GameObject weaponA;
    [HideInInspector]
    public GameObject weaponB;

    PlayerInfo playerInfo;
    //Inventory inven;

    void Awake()
    {
        //weaponA = normalWeapon;
        playerInfo = FindObjectOfType<PlayerInfo>();
        //inven = FindObjectOfType<Inventory>();
        weaponA = playerInfo.playerWeapon;
    }

    void OnEnable()
    {
        IconUPdate();
        playerInfo.playerWeapon = weaponA;
        playerInfo.playerWeaponB = weaponB;
    }

    void IconUPdate()
    {
        weaponASprite.sprite = weaponA.GetComponent<WeaponData>().icon;
        if (weaponB.GetComponent<WeaponData>().icon != null)
        {
            weaponBSprite.sprite = weaponB.GetComponent<WeaponData>().icon;
        }
    }

    //void Update()
    //{
    //    ChangeWeapon();
    //}

    public void OpenWeaponA()
    {
        Debug.Log("무기 A");
        weaponAUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OpenWeaponB()
    {
        Debug.Log("무기 B");
        weaponBUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    //void ChangeWeapon()
    //{
    //    if(Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        GameObject tempObj = weaponA;
    //        weaponA = weaponB;
    //        weaponB = tempObj;

    //        IconUPdate();
    //        // 이거 메인창 꺼져 있어서 안되느ㄴ듯
    //        //inven.playerWeapon = weaponA;
    //        //playerInfo.playerWeapon = weaponA;
    //        playerInfo.WeaponChange(weaponA);
    //    }
    //}

}
