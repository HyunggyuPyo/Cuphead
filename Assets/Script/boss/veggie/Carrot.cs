using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    #region
    private float health = 8f; // 475
    public bool dead = false;
    Animator carrotAnimator;

    public GameObject carrot; // 하이엏라키에 있는 모든 오브젝트 끄고 점수창 띄우기 
    ExplosionPooling fxPool;
    public GameObject ringEyes;
    public GameObject chargingEff;
    CarrotRing carrotRing;
    CarrotRocket carrotRocket;
    public Transform playerPos;
    [HideInInspector]
    public Transform targetPos;
    Coroutine carrotAttack;
    public GameObject clearText;

    GameManager gameManager;
    #endregion

    void Awake()
    {
        carrotAnimator = GetComponent<Animator>();
        fxPool = FindObjectOfType<ExplosionPooling>();
        carrotRing = GetComponent<CarrotRing>();
        carrotRocket = GetComponent<CarrotRocket>();
        gameManager = FindObjectOfType<GameManager>();
        targetPos = this.transform;
    }

    void Update()
    {
        Dead();
        if(gameManager.isGamover == true)
        {
            GameOver();
        }
    }

    void Start()
    {
        carrotAttack = StartCoroutine(Spawn());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
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
            carrotAnimator.SetBool("isDead", true);
            //fxPool.BossDead(11);
            Invoke("Explosion", 2f);
            StopCoroutine(carrotAttack);
            ringEyes.SetActive(false);
            chargingEff.SetActive(false);
            clearText.SetActive(true);
            gameManager.carrotoDead = true;
            gameManager.GameClear();
        }
    }

    void Explosion()
    {
        fxPool.BossDead(11);
    }

    void TargetLock()
    {
        targetPos = playerPos;
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(4f);

        while (true)
        {
            for(int j=0; j < 3; j++)
            {
                //targetPos = playerPos;
                TargetLock();
                carrotAnimator.SetBool("isShoot", true);
                yield return new WaitForSeconds(0.5f);
                ringEyes.SetActive(true);
                chargingEff.SetActive(true);
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < 5; i++)
                {
                    carrotRing.SpawnExplosion();
                    
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(1f);
            }
            ringEyes.SetActive(false);
            carrotAnimator.SetBool("isShoot", false);

            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 4; i++)
            {
                carrotRocket.SpawnRocket();
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    void GameOver()
    {
        StopAllCoroutines();

        ringEyes.SetActive(false);
        chargingEff.SetActive(false);
    }
}
