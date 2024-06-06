using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoShoot : MonoBehaviour
{
    #region
    Transform spawnPos;
    Animator potatoAnimator;
    public GameObject mudObj;
    public GameObject mudParryObj; 
    public GameObject shootDust;
    public float mudSpeed = 8.5f;
    #endregion

    void Awake()
    {
        spawnPos = transform.GetChild(0).transform;
        potatoAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        InvokeRepeating("Shoot", 4f, 6f);
        // ������ ������
        //CancelInvoke("Shoot");
    }

    // ���Ŀ� ��� -> Ǯ�� / ���ڴ� ����?
    // �� ���� �丮 �ѹ� ���� / �� 1�ʿ� �� ���� �� 4�� 3�ʸ��� �߻�
    void Shoot()
    {
        Shot();
        Invoke("Shot", 0.8f);
        Invoke("Shot", 1.6f);
        Invoke("ParryShot", 2.4f);
    }
    // �׳� �ִϸ��̼� �������� 4�� ��� �ִϸ��̼� ���� ��ũ ���߱�?

    void Shot()
    {
        potatoAnimator.SetTrigger("isShoot");
        Invoke("DelayShot", 0.3f);
    }
    void DelayShot()
    {
        Instantiate(shootDust, spawnPos.position, Quaternion.identity);
        Instantiate(mudObj, spawnPos.position, Quaternion.identity);
    }
    
    void ParryShot()
    {
        potatoAnimator.SetTrigger("isShoot");
        Invoke("DelayParryShot", 0.3f); //0.3
    }
    void DelayParryShot()
    {
        Instantiate(shootDust, spawnPos.position, Quaternion.identity);
        Instantiate(mudParryObj, spawnPos.position, Quaternion.identity);
    }

    public void StopShoot()
    {
        CancelInvoke();
    }

}
// invokerepeating �Լ� ����ؼ� 3�ʿ� �Ŀ� ���ʸ��� �ݺ� ���� �ƴ� �̳ʹ̷����ͷ� �ݺ� ����
// InvokeRepeating("Move", 3f, 1f);-> ������Ʈ�� ���� �ʾƵ� ������Ʈ�� �����ϰ� �۵�
// CancelInvoke("Move"); -> �Ķ���͸� ���� ������ ��� InvokeRepeating ����