using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    Sprite[] portraitArr;
    [SerializeField]
    RectTransform selectImage;

    [SerializeField]
    int selectNumber = 0;
    int selectLength;
    bool keyInput;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    private void Update()
    {
        if(keyInput)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectNumber < selectLength-1)
                    selectNumber++;
                else
                    selectNumber = 0;
                ChangeSelectImage();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(selectNumber >= 0)
                    selectNumber--;
                else 
                    selectNumber = selectLength-1;
                ChangeSelectImage();
            }
            else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
            {
                keyInput = false;

                ExcuteChoise();
            }

        }
    }
    
    void GenerateData()
    {
        talkData.Add(110,new string[] { "그럼 쉬기로 할까:1000", "기록\n그만둔다:2" });
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

    void ChangeSelectImage()
    {
        Vector2 change_pos = new Vector2(-40, 20 + selectNumber * -40);
        selectImage.anchoredPosition = change_pos;
    }

    void ExcuteChoise()
    {
        int id = gameManager.scanObject.GetComponent<ObjectData>().id;
        if ( id == 110 && selectNumber == 0)
        {
            gameManager.scanObject.GetComponent<SaveObject>().GameSave();
        }
        selectImage.gameObject.SetActive(false);
        selectNumber = 0;
        ChangeSelectImage();
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

    public void SelectTalk(int Length)
    {
        keyInput = true;
        selectImage.gameObject.SetActive(true);
        selectLength = Length;
    }

}
