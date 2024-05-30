using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카운트 넣어서 1초 이상 이동 했을때만 dust?
public class EffectSpawn : MonoBehaviour
{
    #region
    public GameObject[] effectArray;
    Transform playerPos;
    #endregion

    void Awake()
    {
        playerPos = FindObjectOfType<PlayerMove>().gameObject.transform;
        // 굳이 PlayerMove에서 위치 조정하면 1줄인데 여기서 하는게 맞는지.?
        // ㄴ 플레이어에서 하는게 맞다
    }
    public void MoveDust()
    {
        transform.position = playerPos.position;
        transform.Translate(new Vector2(0f, 0.2f));
        GameObject moveDust = Instantiate(effectArray[0], transform.position, Quaternion.identity);
        Destroy(moveDust, 1.1f);
    }

    public void JumpDust()
    {
        transform.position = playerPos.position;
        transform.Translate(new Vector2(0f, 0.3f));
        GameObject jumpDust = Instantiate(effectArray[1], transform.position, Quaternion.identity);
        Destroy(jumpDust, 1.2f);
    }
    
    public void DashDust()
    {
        transform.position = playerPos.position;
        transform.Translate(new Vector2(0f, 0.3f));
        GameObject dashDust = Instantiate(effectArray[2], transform.position, Quaternion.identity);
        Destroy(dashDust, 1.3f);
    }

    public void ShootSpark()
    {
        transform.position = playerPos.position;
        transform.Translate(new Vector2(0f, 0.3f));
        GameObject shootSpark = Instantiate(effectArray[3], transform.position, Quaternion.identity);
        Destroy(shootSpark, 1.3f);
    }
}
