using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    #region
    private float health = 10f; // 360
    Animator potatoAnimator;
    PotatoShoot potatoshoot;
    ExplosionPooling fxPool;
    private bool dead = false;
    #endregion

    void Awake()
    {
        potatoAnimator = GetComponent<Animator>();
        potatoshoot = FindObjectOfType<PotatoShoot>();
        fxPool = FindObjectOfType<ExplosionPooling>();
    }

    void Update()
    {
        Dead();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Hit();
        }
    }

    void Hit()
    {
        health -= 4f;
        // ���� �߰��ϸ� ���� �ҷ��ͼ� �ش� ������ �������� -
    }

    void Dead()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            potatoshoot.StopShoot();
            potatoAnimator.SetBool("isDead", true);
            fxPool.BossDead();
        }
    }
    // �Լ��ȿ� if�� �����°� update�� if�� �����°� ���� �� ȿ��������?
}
