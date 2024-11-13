using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RocketPos
{
    public float xPos;
    public float yPos;
}

public class CarrotRocket : MonoBehaviour
{
    #region
    public Transform plyerPos;
    //Transform targetPos;
    private int pointer;
    [SerializeField]
    GameObject rocket;
    List<GameObject> rocketPool;
    private int size = 4;
    public RocketPos[] rocketPos;
    #endregion

    void Start()
    {
        pointer = 0;
        rocketPool = new List<GameObject>(0);

        for (int i = 0; i < size; i++)
        {
            GameObject carrotRocket = Instantiate(rocket, transform.position, Quaternion.identity);
            carrotRocket.SetActive(false);
            carrotRocket.transform.parent = transform;
            carrotRocket.transform.localScale = Vector3.one;
            rocketPool.Add(carrotRocket);
        }
    }

    public void SpawnRocket()
    {
        //targetPos = plyerPos;

        if (pointer != rocketPool.Count)
        {
            rocketPool[pointer].transform.position = new Vector2(rocketPos[pointer].xPos, rocketPos[pointer].yPos);
            rocketPool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            pointer = 0;
        }
    }
}
