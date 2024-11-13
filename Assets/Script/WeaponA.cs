using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponA : MonoBehaviour
{
    PlayerInfo playerInfo;
    InvenMain invenMain;
    //Sprite[] icon;
    [SerializeField]
    Image[] buticon1;

    public GameObject mainUI;


    private void Awake()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        invenMain = FindObjectOfType<InvenMain>();
    }

    void OnEnable()
    {
        for (int i = 0; i < playerInfo.weapon.Count; i++)
        {
            if (playerInfo.weapon[i] != null)
            {
                buticon1[i].sprite = playerInfo.weapon[i].GetComponent<WeaponData>().icon;
            }
        }
    }

    void Update()
    {
        OnEsc();
    }

    public void OnBtn1()
    {
        if (playerInfo.weapon[0] != null)
        {
            invenMain.weaponA = playerInfo.weapon[0];
            mainUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    public void OnBtn2()
    {
        if (playerInfo.weapon[1] != null)
        {
            invenMain.weaponA = playerInfo.weapon[1];
            mainUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    public void OnBtn3()
    {
        if (playerInfo.weapon[2] != null)
        {
            invenMain.weaponA = playerInfo.weapon[2];
            mainUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void OnEsc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
