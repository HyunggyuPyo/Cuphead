using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPooling : MonoBehaviour
{
    #region
    int pointer;
    List<GameObject> pool;
    //[SerializeField]
    //GameObject weaponObj;
    GameObject weaponObj;
    public int size = 10;
    List<GameObject> sparkPool;
    [SerializeField]
    GameObject sparkObj;
    int pointerB;
    PlayerInfo playerInfo;
    #endregion

    void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        weaponObj = playerInfo.playerWeapon;
    }

    void Start()
    {
        pointer = 0;
        pool = new List<GameObject>(0);

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(weaponObj, Vector2.zero, weaponObj.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pool.Add(obj);
        }

        pointerB = 0;
        sparkPool = new List<GameObject>(0);

        for (int i = 0; i < size; i++)
        {
            GameObject obj2 = Instantiate(sparkObj, Vector2.zero, sparkObj.transform.rotation);
            obj2.SetActive(false);
            obj2.transform.parent = transform;
            sparkPool.Add(obj2);
        }
    }

    public void SpawnWeapon()
    {
        if (pointer != pool.Count)
        {
            pool[pointer].SetActive(true);
            sparkPool[pointerB].SetActive(true);
            pointer++;

        }
        else
        {
            pointer = 0;
            pool[pointer].SetActive(true);
            sparkPool[pointerB].SetActive(true);
            pointer++;
        }
    }
}
