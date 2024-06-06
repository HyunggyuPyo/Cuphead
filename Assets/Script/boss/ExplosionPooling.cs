using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExplosionVeggie
{
    public float xPos;
    public float yPos;
}

public class ExplosionPooling : MonoBehaviour
{
    #region
    public ExplosionVeggie[] PotatoPos;
    public ExplosionVeggie[] OnionPos;
    
    int pointer;
    List<GameObject> pool;
    [SerializeField]
    GameObject explosion;
    private int pointerSize = 11;
    #endregion

    void Start()
    {
        pointer = 0;
        pool = new List<GameObject>(0);

        for(int i =0;  i < 11; i++)
        {
            GameObject effObj = Instantiate(explosion, new Vector2(PotatoPos[i].xPos, PotatoPos[i].yPos), explosion.transform.rotation);
            effObj.SetActive(false);
            effObj.transform.parent = transform;
            pool.Add(effObj);
        }
    }

    void OnionStart()
    {
        pointer = 0;

        for (int i = 0; i < OnionPos.Length; i++)
        {
            pool[i].transform.position = new Vector2(OnionPos[i].xPos, OnionPos[i].yPos);
        }

    }

    private void SpawnExplosion()
    {
        if(pointer != pointerSize)
        {
            pool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            StopCoroutine(Spawn());
        }
    }

    
    public void BossDead(int size)
    {
        pointerSize = size;

        if(pointerSize == 7)
        {
            OnionStart();
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            SpawnExplosion();
            
            yield return new WaitForSeconds(0.3f);
        }
    }
}
