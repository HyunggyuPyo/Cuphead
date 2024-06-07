using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    #region
    Carrot carrot;
    private float moveSpeed = 2f;
    Animator ringAnimator;
    private int health = 8;
    #endregion

    void Awake()
    {
        carrot = FindObjectOfType<Carrot>();
        ringAnimator = GetComponent<Animator>(); //GetComponent<Animator>();FindObjectOfType
    }

    void Update()
    {
        LookAt();
        Move();
    }

    void LookAt()
    {
        Vector2 newPos = carrot.playerPos.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90f);
    }

    void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    void Death()
    {
        if(health <= 0)
        {
            ringAnimator.SetTrigger("shotDown");
            Invoke("ObjOff", 0.15f);
        }
    }

    void ObjOff()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ringAnimator.SetTrigger("isDead");
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ringAnimator.SetTrigger("isDead");
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "Weapon")
        {
            health -= 4;
            Death();
        }
    }
}
