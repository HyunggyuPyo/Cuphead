using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExplosionPotato
{
    public float xPos;
    public float yPos;
}

public class ExplosionPooling : MonoBehaviour
{
    #region
    public ExplosionPotato[] PotatoPos;
    int pointer;
    List<GameObject> pool;
    [SerializeField]
    GameObject explosion;
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

    private void SpawnExplosion()
    {
        if(pointer != pool.Count)
        {
            pool[pointer].SetActive(true);
            pointer++;
        }
        else
        {
            StopCoroutine(Spawn());
            //pointer = 0;
        }
    }

    
    public void BossDead()
    {
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
