using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoShoot : MonoBehaviour
{
    #region
    Transform spawnPos;
    Animator potatoAnimator;
    public GameObject mudObj;
    public GameObject mudParryObj; 
    public GameObject shootDust;
    #endregion

    void Awake()
    {
        spawnPos = transform.GetChild(0).transform;
        potatoAnimator = GetComponent<Animator>();

    }

    void Start()
    {
        InvokeRepeating("Shoot", 4f, 6f);
        // 보스가 죽으면
        //CancelInvoke("Shoot");
    }

    // 양파와 당근 -> 풀링 / 감자는 굳이?
    // 흙 세번 페리 한번 고정 / 약 1초에 한 번씬 총 4번 3초마다 발사
    void Shoot()
    {

        Shot();
        Invoke("Shot", 1f);
        Invoke("Shot", 2f);
        Invoke("ParryShot", 3f);
    }

    void Shot()
    {
        potatoAnimator.SetTrigger("isShoot");
        Invoke("DelayShot", 0.3f);
    }
    void DelayShot()
    {
        Instantiate(shootDust, spawnPos.position, Quaternion.identity);
        Instantiate(mudObj, spawnPos.position, Quaternion.identity);
    }
    
    void ParryShot()
    {
        potatoAnimator.SetTrigger("isShoot");
        Invoke("DelayParryShot", 0.3f);
    }
    void DelayParryShot()
    {
        Instantiate(shootDust, spawnPos.position, Quaternion.identity);
        Instantiate(mudParryObj, spawnPos.position, Quaternion.identity);
    }

    public void StopShoot()
    {
        CancelInvoke();
    }
}
// invokerepeating 함수 사용해서 3초에 후에 몇초마다 반복 실행 아님 이너미레이터로 반복 실행
// InvokeRepeating("Move", 3f, 1f);-> 업데이트에 넣지 않아도 업데이트와 동일하게 작동
// CancelInvoke("Move"); -> 파라미터를 넣지 않으면 모든 InvokeRepeating 종료