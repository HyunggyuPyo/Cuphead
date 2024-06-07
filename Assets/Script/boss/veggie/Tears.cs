using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : MonoBehaviour
{
    Animator tearsAnimator;
    Rigidbody2D tearsRigid;

    void Awake()
    {
        tearsAnimator = GetComponent<Animator>();
        tearsRigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        tearsRigid.gravityScale = 0.8f;
    }

    void OnDisable()
    {
        float xPos = transform.position.x;
        transform.position = new Vector2(xPos, 1.26f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            tearsRigid.gravityScale = 0;
            float xPos = transform.position.x;
            float yPos = transform.position.y;
            transform.position = new Vector2(xPos, yPos);
            tearsAnimator.SetBool("isBottom", true);
            Invoke("Death", 0.5f);
        }
    }

    void Death()
    {
        gameObject.SetActive(false); 
    }
}
