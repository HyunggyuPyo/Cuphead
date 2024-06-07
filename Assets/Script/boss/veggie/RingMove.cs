using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    #region
    Carrot carrot;
    private float moveSpeed = 4f;
    Animator ringAnimator;
    #endregion

    void Awake()
    {
        carrot = FindObjectOfType<Carrot>();
        ringAnimator = FindObjectOfType<Animator>(); //GetComponent<Animator>();
    }

    void OnEnable()
    {
        LookAt();
    }

    void Update()
    {
        Move();
    }

    void LookAt()
    {
        Vector2 newPos = carrot.targetPos.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
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
    }
}
