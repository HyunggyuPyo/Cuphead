using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMove : MonoBehaviour
{
    private float moveSpeed = 8.5f;
    Animator mudAnimator;

    void Awake()
    {
        mudAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        ShotMove();
        Invoke("Death", 0.8f);
    }

    void ShotMove()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mudAnimator.SetTrigger("isCarsh");
            Death();
        }
    }


    void Death()
    {
        Destroy(gameObject, 0.4f);
    }
}
