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
        talk.Add(0, new string[] { "�̺���! �ƹ����� �̹� ���� �㰡���� ����̷α�?", "��, ���� ������ �׷�����. �׻� ���鿡 �ָ����� ���̾�...",
            "... �ٰ�, �����ϰ�, ���...", "... ������ ������ ��å�̳� �ϰ�, ��ȭ�� ���� �ϴ� �� ����!", "�׷����� ���� ���� �����ְھ�. �̰� �޾�!" });
        talk.Add(1, new string[] { "����, ģ����! �ٽ� ������ �ݰ����!", "�� ������ �����̳��� ������ �Ǹ� ���ڱ�!",
         "�ֺ��� �ٸ� ģ������ ���������. ������ ������ ����!", "��¥��¥ ���̷��� ������ ���� ģ���� ���̾�."});
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
