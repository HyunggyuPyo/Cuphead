using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region
    private float moveSpeed = 4.5f;
    //private int health = 3;
    Animator playerAnimator;
    private PlayerState pState;
    SpriteRenderer rend;
    private float move=0;
    public float jumpPower = 25.0f;
    private bool isBottom = true;
    #endregion

    void Awake()
    {
        playerAnimator = this.GetComponent<Animator>();
        //pState = PlayerState.Start; 씬 전환 후 첫 등장 애니메이션
        StartCoroutine(ChangeState());
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMove();

    }

    void PlayerMove()
    {
        float move = Input.GetAxisRaw("Horizontal");
        move = move * moveSpeed * Time.deltaTime;

        this.gameObject.transform.Translate(Vector2.right * move);

        playerAnimator.SetFloat("isMove", move);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rend.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rend.flipX = true;
            
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetFloat("isMove", -move);
        }
        
        if(Input.GetKey(KeyCode.DownArrow))
        {
            pState = PlayerState.Duck;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("isDuck", false);
            
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(isBottom == true)
            {
                isBottom = false;
                pState = PlayerState.Jump;

                Vector2 jump = new Vector2(0.0f, 0.5f);
                jump = jump * jumpPower;
                this.GetComponent<Rigidbody2D>().velocity = jump;
            }
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("isShoot", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("isShoot", false);
        }

        if(Input.GetKey(KeyCode.X))
        {
            playerAnimator.SetBool("isAim", true);
            //idle 상태로 변경
            moveSpeed = 0.0f;
        }
        if(Input.GetKeyUp(KeyCode.X))
        {
            playerAnimator.SetBool("isAim", false);
            //idle 상태로 변경
            moveSpeed = 4.5f;
        }
        
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("플레이어 착지");
            isBottom = true;
        }
    }

    private IEnumerator ChangeState()
    {
        while(true)
        {
            //yield return AsyncOperation() -> State->start로 시작
            switch (pState)
            {
                case PlayerState.Idle:
                    
                    break;
                case PlayerState.Run:
                    playerAnimator.SetFloat("isMove", move);

                    //pState = PlayerState.Idle;
                    break;
                case PlayerState.Jump:
                    playerAnimator.SetTrigger("isJump");
                    
                    pState = PlayerState.Idle;
                   
                    break;
                case PlayerState.Duck:
                    playerAnimator.SetBool("isDuck", true);
                    pState = PlayerState.Idle;
                    break;
                case PlayerState.Ex:
                    yield return new WaitForSeconds(2f);
                    break;
            }
            
            yield return null;
        }
    }

    public enum PlayerState
    {
        Start,
        Idle,
        Run,
        Jump,
        Duck,
        //Shoot,
        Ex
    }
}
