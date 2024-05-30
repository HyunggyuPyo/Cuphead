using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOff : MonoBehaviour
{
    public float duration;

    void OnEnable()
    {
        Invoke("SetOff", duration);
    }

    void SetOff()
    {
        gameObject.SetActive(false);
    }
}
