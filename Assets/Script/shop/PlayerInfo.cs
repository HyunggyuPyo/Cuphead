using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public List<GameObject> weapon;
    [SerializeField]
    Sprite[] weaponIcon;
    [SerializeField]
    private GameObject normalWeapon;

    public static int coin { get; private set; }
    public static PlayerInfo instance = null;

    [HideInInspector]
    public GameObject playerWeapon;
    public GameObject playerWeaponB;

    public int pDmg;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            coin = 0;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        weapon = new List<GameObject>(0);
        weapon.Add(normalWeapon);
        
        playerWeapon = normalWeapon;
        pDmg = playerWeapon.GetComponent<WeaponData>().dmg;
    }

    public static bool Pay(int price)
    {
        if (coin < price)
        {
            return false;
        }
        else
        {
            coin -= price;
            return true;
        }
    }

    public void BuyWeapon(GameObject newWeapon)
    {
        weapon.Add(newWeapon);
    }

    void IconArray()
    {
        for (int i = 0; i < weapon.Count; i++)
        {
            Sprite weaponicon = weapon[i].GetComponent<WeaponData>().icon;
            weaponIcon[i] = weaponicon;
        }
    }

    public Sprite[] GetWeaponArray()
    {
        IconArray();

        return weaponIcon;
    }

    public static void BonusCoin()
    {
        coin = 3;
    }

    public void WeaponChange(bool change)
    {
        if(change == false)
        {
            pDmg = playerWeapon.GetComponent<WeaponData>().dmg;
        }
        else
        {
            pDmg = playerWeaponB.GetComponent<WeaponData>().dmg;
        }
        
    }
}
