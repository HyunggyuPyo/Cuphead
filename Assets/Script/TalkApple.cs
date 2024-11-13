using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkApple : MonoBehaviour
{
    [SerializeField]
    GameObject getCoin;
    Dictionary<int, string[]> talk;
    [SerializeField]
    Text talkText;
    int tkey = 0;
    int tindex = 0;

    void Awake()
    {
        talk = new Dictionary<int, string[]>();
        TalkAdd();
    }

    void Start()
    {
        Talk();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(tkey == 0 && tindex == talk[tkey].Length)
            {
                tkey = 1;
                getCoin.SetActive(true);
                gameObject.SetActive(false);
            }
            else if(tkey == 1 && tindex == talk[tkey].Length)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Talk();
            }
            
        }
    }

    void TalkAdd()
    {
        talk.Add(0, new string[] { "이봐들! 아무래도 이미 발을 담가버린 모양이로군?", "뭐, 나도 예전엔 그랬었지. 항상 말썽에 휘말리고 말이야...",
            "... 뛰고, 점프하고, 쏘고...", "... 하지만 이제는 산책이나 하고, 영화나 보고 하는 게 좋아!", "그렇지만 내가 손을 빌려주겠어. 이걸 받아!" });
        talk.Add(1, new string[] { "어이, 친구들! 다시 만나니 반가운걸!", "그 코인이 조금이나마 도움이 되면 좋겠군!",
         "주변의 다른 친구들을 만나보라고. 도움이 될지도 몰라!", "다짜고짜 죽이려고 덤비지 않을 친구들 말이야."});
    }


    void Talk()
    {
        talkText.text = GetTalk(tkey, tindex);
        tindex++;
    }

    string GetTalk(int id, int tIndex)
    {
        if (tIndex == talk[id].Length)
        {
            tkey = 1;
            return null;
        }
        else
        {
            return talk[id][tIndex];
        }
    }
}
