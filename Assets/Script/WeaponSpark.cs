using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpark : MonoBehaviour
{
    #region
    Transform SpawnPos;
    ShootDirection instanceAngle;
    #endregion

    void Awake()
    {
        SpawnPos = FindObjectOfType<PlayerMove>().gameObject.transform;
        instanceAngle = FindObjectOfType<ShootDirection>();
    }

    void OnEnable()
    {
        StartCoroutine(PlayAni());
        float shotAngle = instanceAngle.angle;
        float reveresShoot = instanceAngle.reverse;
        float xpos = instanceAngle.xPos;
        float ypos = instanceAngle.yPos;

        transform.position = SpawnPos.position;
        transform.rotation = Quaternion.Euler(0f, reveresShoot, shotAngle);
        transform.Translate(new Vector2(xpos, ypos), Space.World);
    }
    // �� �Լ��� �������� �Ϻ��ϰ� ShootMove ��ũ��Ʈ�� �����ѵ� ��� �� �� �ִ���?

    void OnDisable()
    {
        StopCoroutine(PlayAni());
    }

    IEnumerator PlayAni()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(false);
        }
    }
}
