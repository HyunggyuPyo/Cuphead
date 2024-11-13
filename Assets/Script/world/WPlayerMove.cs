using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPlayerMove : MonoBehaviour
{
    #region
    Rigidbody2D rigid;
    Animator playerAnimator;
    SpriteRenderer playerSprite;

    private float moveSpeed = 3f;
    private float xPos = 0f;
    private float yPos = 0f;

    public GameObject enterImage;
    #endregion

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        PlayerMove();
        Diection();
    }

    void PlayerMove()
    {
        xPos = Input.GetAxisRaw("Horizontal");
        yPos = Input.GetAxisRaw("Vertical");

        xPos = xPos * moveSpeed * Time.deltaTime;
        yPos = yPos * moveSpeed * Time.deltaTime;

        rigid.transform.Translate(new Vector2(xPos, yPos));

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerSprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerSprite.flipX = true;
        }
    }

    void Diection()
    {
        if (xPos == 0)
        {
            playerAnimator.SetBool("keyHorizon", false);
        }
        else
        {
            playerAnimator.SetBool("keyHorizon", true);
        }

        if (yPos == 0)
        {
            playerAnimator.SetBool("keyDown", false);
            playerAnimator.SetBool("keyUp", false);
            playerAnimator.SetBool("keyVerti", false);
            playerAnimator.SetBool("isWalk", false);
        }
        else if(yPos < 0)
        {
            playerAnimator.SetBool("keyDown", true);
            playerAnimator.SetBool("keyVerti", true);
            playerAnimator.SetBool("isWalk", true);
        }
        else
        {
            playerAnimator.SetBool("keyUp", true);
            playerAnimator.SetBool("keyVerti", true);
            playerAnimator.SetBool("isWalk", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Icon")
        {
            enterImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Icon")
        {
            enterImage.SetActive(false);
        }
    }

    public void CantMove()
    {
        moveSpeed = 0f;
    }
    public void CanMove()
    {
        moveSpeed = 3f;
    }
}
