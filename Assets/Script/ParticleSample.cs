using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CTargetInfo 
{
    public GameObject partcleObj;
    public float buffTime;
}


public class ParticleSample : MonoBehaviour
{
    public CTargetInfo[] partcleObj;
    Transform playerPos;
    GameObject Buff;

    void Awake()
    {
        playerPos = FindObjectOfType<PlayerMove>().gameObject.transform;
        transform.position = playerPos.position;
    }

    void Update()
    {
        Buff.transform.position = transform.position;
    }

    void GetBuff(int i)
    {
        if(Buff != null)
        {
            Destroy(Buff);
        }
        Buff = Instantiate(partcleObj[i].partcleObj, transform.position, Quaternion.identity);
        Buff.transform.Rotate(new Vector3(11f, 0f, 0f), Space.World);
        Destroy(Buff, this.partcleObj[i].buffTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ItemHeal")
        {
            Debug.Log("버프 공");
            GetBuff(1);
        }
        if (collision.gameObject.tag == "ItemDmgUp")
        {
            Debug.Log("버프 힐");
            GetBuff(0);
        }
        if (collision.gameObject.tag == "ItemSpeedUp")
        {
            Debug.Log("버프 스피드");
            GetBuff(2);
        }
    }

}
