using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDirection : MonoBehaviour
{
    #region
    private bool keyHori, keyVart = false;
    private float hori, vart = 0f;

    [HideInInspector]
    public float angle = 0f;
    public float reverse = 0f;
    public float xPos = 0.5f;
    public float yPos = 0.8f;
    #endregion

    void Awake()
    {
        StartCoroutine(GetKeyValue());
        StartCoroutine(GetDirection());
    }

    void OnDisable()
    {
        StopCoroutine(GetKeyValue());
        StopCoroutine(GetDirection());
    }

    IEnumerator GetKeyValue()
    {
        while (true)
        {
            hori = Input.GetAxisRaw("Horizontal");
            vart = Input.GetAxisRaw("Vertical");

            if (hori != 0)
            {
                keyHori = true;
            }
            else
            {
                keyHori = false;
            }

            if (vart != 0)
            {
                keyVart = true;
            }
            else
            {
                keyVart = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator GetDirection()
    {
        while (true)
        {
            if (hori == -1)
            {
                reverse = 180f;
            }
            else if (hori == 1)
            {
                reverse = 0f;
            }

            if (keyVart == false)
            {
                angle = 0f;
                xPos = 0.5f;
                yPos = 0.8f;
                if(reverse == 180)
                {
                    xPos = -0.5f;
                }
            }
            else if (keyHori == true && keyVart == true && vart != -1)
            {
                angle = 45f;
                xPos = 0.5f;
                yPos = 1.1f;
                if (reverse == 180)
                    xPos *= -1f;
            }
            else if (keyHori == false && keyVart == true)
            {
                angle = 90f;
                xPos = 0.3f;
                yPos = 1.6f; //1.5

                if (vart == -1f)
                {
                    angle = 0f;
                    xPos = 0.6f;
                    yPos = 0.5f;
                }
                if (reverse == 180)
                {
                    xPos *= -1f;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
