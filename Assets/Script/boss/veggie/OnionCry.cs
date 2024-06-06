using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionCry : MonoBehaviour
{
    #region
    private bool firstHit = false;
    private bool tearsSpawn = false;
    Animator onionAnimator;
    Animator tearRightAnimator;
    Animator tearLeftAnimator;
    public GameObject[] tearsL;
    public GameObject[] tearsR;
    GameObject tearRightAni;
    GameObject tearLeftAni;
    Coroutine cryingCoroutine, spawnTearsCoroutine;
    GameManager gameManager;
    #endregion

    void Awake()
    {
        onionAnimator = GetComponent<Animator>();
        tearRightAni = transform.GetChild(0).gameObject;
        tearRightAnimator = tearRightAni.GetComponent<Animator>();

        tearLeftAni = transform.GetChild(1).gameObject;
        tearLeftAnimator = tearLeftAni.GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(gameManager.isGamover == true)
        {
            GameOver();
        }
    }

    public void StopCrying()
    {
        StopCoroutine(spawnTearsCoroutine);
        StopCoroutine(cryingCoroutine);

        tearsSpawn = false;
        tearLeftAni.SetActive(false);
        tearRightAni.SetActive(false);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!firstHit && collision.gameObject.tag == "Weapon")
        {
            firstHit = true;
            cryingCoroutine = StartCoroutine(Crying());
            spawnTearsCoroutine =  StartCoroutine(SpawnTears());
        }
    }
    IEnumerator SpawnTears()
    {
        int count = 0;

        while (true)
        {
            if (tearsSpawn)
            {
                tearsL[count].SetActive(true);
                tearsR[count].SetActive(true);
                count++;
                if(tearsL.Length <= count)
                {
                    count = 0;
                }
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    IEnumerator Crying()
    {
        while (true)
        {
            tearRightAni.SetActive(true);
            tearLeftAni.SetActive(true);

            tearRightAnimator.SetBool("Crying", true);
            tearLeftAnimator.SetBool("Crying", true);

            onionAnimator.SetBool("Crying", true);
            yield return new WaitForSeconds(1f);

            tearsSpawn = true;
            yield return new WaitForSeconds(5f);

            tearsSpawn = false;
            tearRightAnimator.SetBool("Crying", false);
            tearLeftAnimator.SetBool("Crying", false); 
            yield return new WaitForSeconds(0.3f);

            tearLeftAni.SetActive(false);
            tearRightAni.SetActive(false);
            onionAnimator.SetBool("Crying", false);
            yield return new WaitForSeconds(1f);
        }
    }

    void GameOver()
    {
        StopAllCoroutines();

        tearsSpawn = false;
        tearLeftAni.SetActive(false);
        tearRightAni.SetActive(false);
    }
}
