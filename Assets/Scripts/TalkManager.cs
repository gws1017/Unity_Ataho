using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    [SerializeField]
    Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000,new string[] { "그럼 쉬기로 할까:1000", "기록\n그만둔다:0" });
        talkData.Add(100,new string[] { "아무것도 들어있지 않다." });

        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1100, portraitArr[1]);
        portraitData.Add(1200, portraitArr[2]);
        portraitData.Add(1300, portraitArr[3]);
        portraitData.Add(1400, portraitArr[4]);
        portraitData.Add(1500, portraitArr[5]);
        portraitData.Add(1600, portraitArr[6]);
        portraitData.Add(1700, portraitArr[7]);
        portraitData.Add(1800, portraitArr[8]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id)
    {
        return portraitData[id];
    }

}
