using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    #region
    private float health = 12f; // 양파: 400, 당든: 475
    private bool dead = false;
    //private bool firstHit = false;
    Animator onionAnimator;
    OnionCry onionCry;
    #endregion

    void Awake()
    {
        onionAnimator = GetComponent<Animator>();
        onionCry = FindObjectOfType<OnionCry>();
        //onionCry = GetComponent<OnionCry>();  
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
        }
    }
}
