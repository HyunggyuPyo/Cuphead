using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region
    WeaponPooling instancePool;
    private float delay = 8;
    #endregion
    void Start()
    {
        instancePool = FindObjectOfType<WeaponPooling>();
    }

    void FixedUpdate()
    {
        delay++;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(8 <= delay)
            {
                StartCoroutine(Shoot());
                delay = 0;
            }
        }
    }

    IEnumerator Shoot()
    {
        instancePool.SpawnWeapon();
        yield return new WaitForSeconds(3f);
    }
}
