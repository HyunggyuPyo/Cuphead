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

    void Awake()
    {
        //playerInfo = FindObjectOfType<PlayerInfo>();
        //weaponA = playerInfo.weapon[0];
        weaponA = normalWeapon;
    }

    void OnEnable()
    {
        weaponASprite.sprite = weaponA.GetComponent<ShootMove>().icon;
        weaponBSprite.sprite = weaponB.GetComponent<ShootMove>().icon;
    }

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

}
