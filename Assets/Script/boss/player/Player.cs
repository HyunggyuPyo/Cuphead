using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region
    private int maxHealth = 30;
    private int health;
    Animator playerAnimator;
    //private float card = 0;
    private bool invincibilityTime = false;
    public GameObject[] playerHpBar;
    ShootMove shootMove;
    GameManager gameManager;
    SpriteRenderer playerSprite;
    Coroutine playerInvincibility;
    PlayerMove playerMove;
    #endregion

    void Awake()
    {
        health = maxHealth;
        playerAnimator = GetComponent<Animator>();
        shootMove = FindObjectOfType<ShootMove>();
        gameManager = FindObjectOfType<GameManager>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerMove = GetComponent<PlayerMove>();
    }

    //void Update()
    //{
    //    shootMove.cardPiece
    //}

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincibilityTime && health != 0)
        {
            if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Enemy")
            {
                playerHpBar[health].SetActive(false);
                invincibilityTime = true;
                playerInvincibility = StartCoroutine(PlayerInvincibility());
                health -= 1;
                GameOver();
                playerAnimator.SetTrigger("isHit");
                Invoke("PlayerHit", 2f);
            }
        }
    }

    void PlayerHit()
    {
        invincibilityTime = false;
    }

    void GameOver()
    {
        if (health <= 0)
        {
            gameManager.PlayerDead();
            playerMove.PlayerDead();
        }
    }

    IEnumerator PlayerInvincibility()
    {
        Color spriteColor = playerSprite.material.color;

        while (invincibilityTime)
        {
            spriteColor.a = 0;
            playerSprite.material.color = spriteColor;
            yield return new WaitForSeconds(0.1f);

            spriteColor.a = 1;
            playerSprite.material.color = spriteColor;
            yield return new WaitForSeconds(0.1f);
        }

        spriteColor.a = 1;
        playerSprite.material.color = spriteColor;
        StopCoroutine(playerInvincibility);
    }
}
