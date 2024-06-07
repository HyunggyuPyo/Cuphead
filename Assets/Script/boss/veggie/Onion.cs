using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    #region
    private float health =8f; // 양파: 400
    public bool dead = false;
    //private bool firstHit = false;
    Animator onionAnimator;
    OnionCry onionCry;
    private int size = 3;
    public List<SpriteRenderer> spritList;
    public GameObject onion;
    ExplosionPooling fxPool;
    GameManager gameManager;
    public GameObject carrot;
    #endregion

    void Awake()
    {
        onionAnimator = GetComponent<Animator>();
        onionCry = FindObjectOfType<OnionCry>();
        //onionCry = GetComponent<OnionCry>();  
        fxPool = FindObjectOfType<ExplosionPooling>();
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < size; i++)
        {
            SpriteRenderer sprit = spritList[i].GetComponent<SpriteRenderer>();
            spritList.Add(sprit);
        }
    }

    void Update()
    {
        Dead();
    }

    void OnDisable()
    {
        StopCoroutine(Exit());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Hit();
        }
    }
    // 보스들 인터페이스 만들어서 상속
    void Hit()
    {
        health -= 4;
        // health -= player.weapon.dmg;
    }
    void Dead()
    {
        if (health <= 0 && !dead)
        {
            dead = true;
            onionCry.StopCrying();
            onionAnimator.SetBool("isDead", true);
            fxPool.BossDead(7);
            StartCoroutine(Exit());
            gameManager.onionDead = true;
        }
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(4f);

        for (int i = 10; i >= 0; i--)
        {
            float fade = i / 10.0f;

            for (int j = 0; j < spritList.Count; j++)
            {
                Color spriteColor = spritList[j].material.color;
                spriteColor.a = fade;
                spritList[j].material.color = spriteColor;
            }

            yield return new WaitForSeconds(0.1f);
        }
        carrot.SetActive(true);
        onion.SetActive(false);
    }

    //public void GameOver()
    //{
    //    onionCry.GameOver();
    //}
}
