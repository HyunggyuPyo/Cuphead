using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcApple : MonoBehaviour
{
    Animator appleAni;
    [SerializeField]
    GameObject talk;
    private bool first = false;
    

    void Awake()
    {
        appleAni = GetComponent<Animator>(); 
    }

    void OnBecameVisible()
    {
        appleAni.SetBool("isWave", true);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(!first && Input.GetKeyDown(KeyCode.Z))
        {
            talk.SetActive(true);
            first = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        appleAni.SetBool("isWave", false);
    }

    
}
