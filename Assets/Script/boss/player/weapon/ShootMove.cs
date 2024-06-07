using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    #region
    IEnumerator cfunc;
    UnityEngine.Coroutine ShootCoroutine;
    bool weaponMove = true;
    Transform SpawnPos;
    Animator weaponAnimator;
    ShootDirection instanceAngle;
    public float cardPiece = 0f;
    public Sprite icon;
    #endregion

    void Awake()
    {
        weaponAnimator = this.GetComponent<Animator>();
        SpawnPos = FindObjectOfType<PlayerMove>().gameObject.transform;
        instanceAngle = FindObjectOfType<ShootDirection>();
    }

    void OnEnable()
    {
        float shotAngle = instanceAngle.angle;
        float reveresShoot = instanceAngle.reverse;
        float xpos = instanceAngle.xPos;
        float ypos = instanceAngle.yPos;

        cfunc = Move();
        ShootCoroutine = StartCoroutine(cfunc);
        transform.position = SpawnPos.position;
        transform.rotation = Quaternion.Euler(0f, reveresShoot, shotAngle);
        transform.Translate(new Vector2(xpos, ypos), Space.World);
        //transform.Translate(new Vector2(0.5f, 1.1f), Space.World);
    }

    void OnDisable()
    {
        StopCoroutine(cfunc);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossTrigger")
        {
            weaponAnimator.SetBool("isDeath", true);
            weaponMove = false;
            cardPiece += 0.05f;
        }
    }

    IEnumerator Move()
    {
        StartCoroutine(Stop());

        while (weaponMove)
        {
            //transform.Translate(transform.right * 10f * Time.deltaTime, Space.Self);
            transform.Translate(Vector3.right * 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.4f);

        gameObject.SetActive(false);
        weaponMove = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        weaponMove = false;
    }
}
