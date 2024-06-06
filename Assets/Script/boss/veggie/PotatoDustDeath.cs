using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoDustDeath : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.7f);
    }
}
