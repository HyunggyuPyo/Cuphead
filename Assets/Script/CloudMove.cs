using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CloudArray
{
    public GameObject clouds;
    public float moveSpeed;
}
public class CloudMove : MonoBehaviour
{
    public CloudArray[] cloudArray;

    void Update()
    {
        Move();
    }
    void Move()
    {
        for(int i =0; i < cloudArray.Length; i++)
        {
            Transform cloudePos = cloudArray[i].clouds.transform;

            cloudePos.Translate(Vector2.left * cloudArray[i].moveSpeed * Time.deltaTime);

            if (cloudePos.position.x <= -9f) //-10
            {
                float yPos = cloudePos.position.y;
                cloudePos.position = new Vector2(9f, yPos);
            }
        }
        
    }
}

//for (int i = 0; i < cloudArray.Length; i++)
//{
//    cloudArray[i].clouds.transform.Translate(Vector2.left * cloudArray[i].moveSpeed * Time.deltaTime);

//    if (cloudArray[i].clouds.transform.position.x <= -9f) //-10
//    {
//        float yPos = cloudArray[i].clouds.transform.position.y;
//        cloudArray[i].clouds.transform.position = new Vector2(9f, yPos);
//    }
//}
