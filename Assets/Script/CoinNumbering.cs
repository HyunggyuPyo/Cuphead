using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinNumbering : MonoBehaviour
{
    [SerializeField]
    GameObject numberSprite;
    [SerializeField]
    Sprite[] coinNumber;

    void Update()
    {
        CoinNumber();
    }

    void CoinNumber()
    {
        switch (PlayerInfo.coin)
        {
            case 0:
                numberSprite.GetComponent<SpriteRenderer>().sprite = coinNumber[0];
                break;
            case 1:
                numberSprite.GetComponent<SpriteRenderer>().sprite = coinNumber[1];
                break;
            case 2:
                numberSprite.GetComponent<SpriteRenderer>().sprite = coinNumber[2];
                break;
            case 3:
                numberSprite.GetComponent<SpriteRenderer>().sprite = coinNumber[3];
                break;
            case 4:
                numberSprite.GetComponent<SpriteRenderer>().sprite = coinNumber[4];
                break;
        }
    }
}
