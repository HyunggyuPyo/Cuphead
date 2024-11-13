using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPooling : MonoBehaviour
{
    #region
    int pointer;
    List<GameObject> pool;
    List<GameObject> poolB;
    public int size = 10;
    List<GameObject> sparkPool;
    List<GameObject> sparkBPool;
    //[SerializeField]
    //GameObject sparkObj;
    int pointerB;
    PlayerInfo playerInfo;

    private bool weaponTab = false;
    #endregion

    void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    void Start()
    {
        pointer = 0;
        pool = new List<GameObject>(0);
        GameObject weaponObj = playerInfo.playerWeapon;

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(weaponObj, Vector2.zero, weaponObj.transform.rotation);
            obj.SetActive(false);
            obj.transform.parent = transform;
            pool.Add(obj);
        }

        pointerB = 0;
        sparkPool = new List<GameObject>(0);
        GameObject sparkObj = playerInfo.playerWeapon.GetComponent<WeaponData>().spark;

        for (int i = 0; i < size; i++)
        {
            GameObject obj2 = Instantiate(sparkObj, Vector2.zero, sparkObj.transform.rotation);
            obj2.SetActive(false);
            obj2.transform.parent = transform;
            sparkPool.Add(obj2);
        }

        poolB = new List<GameObject>(0);
        GameObject weaponBObj = playerInfo.playerWeaponB;

        for (int i = 0; i < size; i++)
        {
            GameObject objB = Instantiate(weaponBObj, Vector2.zero, weaponBObj.transform.rotation);
            objB.SetActive(false);
            objB.transform.parent = transform;
            poolB.Add(objB);
        }

        sparkBPool = new List<GameObject>(0);
        GameObject sparkB = playerInfo.playerWeaponB.GetComponent<WeaponData>().spark;

        for (int i = 0; i < size; i++)
        {
            GameObject obj2 = Instantiate(sparkB, Vector2.zero, sparkB.transform.rotation);
            obj2.SetActive(false);
            obj2.transform.parent = transform;
            sparkBPool.Add(obj2);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!weaponTab)
            {
                weaponTab = true;
                playerInfo.WeaponChange(weaponTab);
            }
            else
            {
                weaponTab = false;
                playerInfo.WeaponChange(weaponTab);
            }
        }
    }

    public void SpawnWeapon()
    {
        if(!weaponTab)
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
        else
        {
            if (pointer != pool.Count)
            {
                poolB[pointer].SetActive(true);
                sparkBPool[pointerB].SetActive(true);
                pointer++;

            }
            else
            {
                pointer = 0;
                poolB[pointer].SetActive(true);
                sparkBPool[pointerB].SetActive(true);
                pointer++;
            }
        }
        
    }
}
