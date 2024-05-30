using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī��Ʈ �־ 1�� �̻� �̵� �������� dust?
public class EffectSpawn : MonoBehaviour
{
    #region
    public GameObject[] effectArray;
    Transform playerPos;
    #endregion

    void Awake()
    {
        playerPos = FindObjectOfType<PlayerMove>().gameObject.transform;
        // ���� PlayerMove���� ��ġ �����ϸ� 1���ε� ���⼭ �ϴ°� �´���.?
        // �� �÷��̾�� �ϴ°� �´�
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
