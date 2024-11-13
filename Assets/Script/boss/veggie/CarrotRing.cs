using System.Collections.Generic;
using UnityEngine;

public class CarrotRing : MonoBehaviour
{
    #region
    Transform spawnPos;
    Animator carrotAnimator;
    private int pointer;
    [SerializeField]
    GameObject rocket;
    List<GameObject> ringPool;
    private int size = 5;
    #endregion

    void Awake()
    {
        spawnPos = transform.GetChild(0).transform;
        carrotAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        pointer = 0;
        ringPool = new List<GameObject>(0);

        for (int i = 0; i < size; i++)
        {
            GameObject carrotRing = Instantiate(rocket, spawnPos.position, Quaternion.identity);
            carrotRing.SetActive(false);
            carrotRing.transform.parent = transform;
            carrotRing.transform.localScale = Vector3.one;
            ringPool.Add(carrotRing);
        }
    }

    public void SpawnExplosion()
    {
        if (pointer != ringPool.Count)
        {
            ringPool[pointer].transform.position = spawnPos.position;
            ringPool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            pointer = 0;
        }
    }
}
