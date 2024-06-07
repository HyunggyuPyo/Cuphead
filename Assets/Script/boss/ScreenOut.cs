using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOut : MonoBehaviour
{
    SpriteRenderer Screen;
    Coroutine sprite;
    public GameObject veggie;
    public GameObject winScreen;

    void Awake()
    {
        Screen = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        sprite = StartCoroutine(Sprite());
    }

    IEnumerator Sprite()
    {
        Color startcolor = Screen.material.color;
        startcolor.a = 0f;
        Screen.material.color = startcolor;

        yield return new WaitForSeconds(4f);

        for (int i = 0; i <= 10; i++)
        {
            float fade = i / 10.0f;

            Color spriteColor = Screen.material.color;
            spriteColor.a = fade;
            Screen.material.color = spriteColor;

            yield return new WaitForSeconds(0.2f);
        }

        veggie.SetActive(false);
        yield return new WaitForSeconds(2f);

        winScreen.SetActive(true);

        for (int i = 5; i >= 0; i--)
        {
            float fade = i / 5.0f;

            Color spriteColor = Screen.material.color;
            spriteColor.a = fade;
            Screen.material.color = spriteColor;

            yield return new WaitForSeconds(0.1f);
        }
        
        StopCoroutine(sprite);
    }
}
