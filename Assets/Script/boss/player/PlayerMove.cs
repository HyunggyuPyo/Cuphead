using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region
    private float moveSpeed = 4.5f;
    Animator playerAnimator;
    private PlayerState pState;
    SpriteRenderer rend;
    Rigidbody2D rigid;
    private float move = 0;
    private float jumpPower = 31f; // 25.0
    private float dashPower = 10f;
    //[HideInInspector]
    private bool isBottom = true;
    private bool isDash = false;
    EffectSpawn instanceEffect;
    private int dustDelay = 0;
    private bool canParry = false;
    public GameObject parryEff;
    public bool dead = false;
    //private float temp = 0f;
    #endregion

    void Awake()
    {
        playerAnimator = this.GetComponent<Animator>();
        //pState = PlayerState.Start; 씬 전환 후 첫 등장 애니메이션
        StartCoroutine(ChangeState());
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        instanceEffect = FindObjectOfType<EffectSpawn>();
    }

    void Update()
    {
        if(!dead)
        {
            Move();
            Dash();
            Aiming();
            Shoot();
            //AimGetKey();
        }
    }

    public void PlayerDead()
    {
        dead = true;
    }

    void Move()
    { 
        float move = Input.GetAxisRaw("Horizontal");
        //if (isDash)
        //{
        //    move = temp;
        //}
        //temp = move;
        move = move * moveSpeed * Time.deltaTime;

        this.gameObject.transform.Translate(Vector2.right * move);
        playerAnimator.SetFloat("isMove", move);

        if(move != 0)
        {
            dustDelay++;
        }
        else
        {
            dustDelay = 0;
        }
        if(move != 0 && isBottom && 100f <= dustDelay)
        {
            instanceEffect.MoveDust();
            dustDelay = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isDash)
        {
            rend.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isDash)
        {
            rend.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetFloat("isMove", -move);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pState = PlayerState.Duck;
            moveSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("isDuck", false);
            moveSpeed = 4.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerAnimator.SetBool("keyUA", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnimator.SetBool("keyUA", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(canParry && !isBottom)
            {
                canParry = false;
                pState = PlayerState.Parry;

                Vector2 jump = new Vector2(0.0f, 0.4f);
                jump = jump * jumpPower;
                this.GetComponent<Rigidbody2D>().velocity = jump;
            }
            else if (isBottom == true)
            {
                isBottom = false;
                pState = PlayerState.Jump;

                Vector2 jump = new Vector2(0.0f, 0.5f);
                jump = jump * jumpPower;
                this.GetComponent<Rigidbody2D>().velocity = jump;
            }
        }
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("isShoot", true);
            AimGetKey();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnimator.SetBool("isShoot", false);
        }
    }

    void Aiming()
    {
        if (Input.GetKey(KeyCode.X))
        {
            playerAnimator.SetBool("isAim", true);
            //idle 상태로 변경
            moveSpeed = 0.0f;
            AimGetKey();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            playerAnimator.SetBool("isAim", false);
            //idle 상태로 변경
            moveSpeed = 4.5f;
        }
    }

    void AimGetKey()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetBool("keyHori", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnimator.SetBool("keyHori", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("keyDA", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("keyDA", false);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isDash) // && move != 0
        {
            isDash = true;
            pState = PlayerState.Dash;
            if (rend.flipX == true)
            {
                Vector2 dash = new Vector2(0.5f, 0.0f);
                dash = dash * dashPower;
                this.GetComponent<Rigidbody2D>().velocity = -dash;
            }
            else
            {
                Vector2 dash = new Vector2(0.5f, 0.0f);
                dash = dash * dashPower;
                this.GetComponent<Rigidbody2D>().velocity = dash;
            }
            instanceEffect.DashDust();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(isBottom == false)
            {
                isBottom = true;
                instanceEffect.JumpDust();
            }
            
            playerAnimator.SetBool("isAir", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Parry")
        {
            canParry = true;
            Invoke("CantParry", 1f);
        }
    }

    void CantParry()
    {
        canParry = false;
    }

    private IEnumerator ChangeState()
    {
        while (true)
        {
            //yield return AsyncOperation() -> State->start로 시작
            switch (pState)
            {
                case PlayerState.Idle:
                    isDash = false;
                    
                    //moveSpeed = 4.5f;
                    break;
                case PlayerState.Run:
                    playerAnimator.SetFloat("isMove", move);

                    //pState = PlayerState.Idle;
                    break;
                case PlayerState.Jump:
                    playerAnimator.SetTrigger("isJump");
                    playerAnimator.SetBool("isAir", true);

                    pState = PlayerState.Idle;
                    break;
                case PlayerState.Parry:
                    playerAnimator.SetTrigger("isParry");
                    parryEff.SetActive(true);
                    playerAnimator.SetBool("isAir", true);
                    pState = PlayerState.Idle;
                    yield return new WaitForSeconds(0.3f);
                    parryEff.SetActive(false); 
                    break;
                case PlayerState.Dash:
                    playerAnimator.SetTrigger("isDash");
                    rigid.gravityScale = 0.0f;
                    yield return new WaitForSeconds(0.2f); //0.15f
                    rigid.gravityScale = 3.0f;
                    //moveSpeed = 0;
                    //yield return new WaitForSeconds(0.15f);
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
        Parry,
        Duck,
        Dash,
        Ex
        //Shoot,
        //Air,
        //Normal
    }
}
