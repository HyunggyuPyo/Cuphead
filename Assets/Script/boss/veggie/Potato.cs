using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    #region
    private float health = 360f; // 360
    public bool dead = false;
    Animator potatoAnimator;
    PotatoShoot potatoshoot;
    ExplosionPooling fxPool;
    public List<SpriteRenderer> spritList;
    public GameObject potato;
    private int size = 4;
    GameManager gameManager;

    public GameObject onion;
    #endregion

    void Awake()
    {
        potatoAnimator = GetComponent<Animator>();
        potatoshoot = FindObjectOfType<PotatoShoot>();
        fxPool = FindObjectOfType<ExplosionPooling>();
        gameManager = FindObjectOfType<GameManager>();

        for (int i =0; i < size; i++)
        {
            SpriteRenderer sprit = spritList[i].GetComponent<SpriteRenderer>();
            spritList.Add(sprit);
        }
        
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

    void OnDisable()
    {
        StopCoroutine(Exit());
    }

    void Hit()
    {
        health -= 4f;
        // 상점 추가하면 무기 불러와서 해당 무기의 데미지를 -
    }

    void Dead()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            potatoshoot.StopShoot();
            potatoAnimator.SetBool("isDead", true);
            fxPool.BossDead(11);
            StartCoroutine(Exit());
            gameManager.potatoDead = true;
        }
    }
    // 함수안에 if문 돌리는거 update에 if문 돌리는거 뭐가 더 효율적인지?

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(4f);

        for(int i =10; i >=0; i--)
        {
            float fade = i / 10.0f;

            for(int j =0; j < spritList.Count; j++)
            {
                Color spriteColor = spritList[j].material.color;
                spriteColor.a = fade;
                spritList[j].material.color = spriteColor;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        potato.SetActive(false);
        onion.SetActive(true);
    }

    public void GameOver()
    {
        potatoshoot.StopShoot();
    }
}
