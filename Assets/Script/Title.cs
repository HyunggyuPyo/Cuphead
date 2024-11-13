using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject titleText;
    public GameObject book;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            fadeOut.SetActive(true);
            Invoke("FadeOut", 1.5f);
            Invoke("ObjOff", 3f);
        }
    }
    void FadeOut()
    {
        titleText.SetActive(false);
        book.SetActive(true);
    }
    void ObjOff()
    {
        gameObject.SetActive(false);
    }
}
