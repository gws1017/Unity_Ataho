using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    TalkManager talkManager;
    [SerializeField]
    Image portaitImage;
    [SerializeField]
    GameObject talkPannel;
    [SerializeField]
    Text talkText;
    [SerializeField]
    int talkIndex;

    public GameObject scanObject;
    public bool isAction;


    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObj.GetComponent<ObjectData>();
        Talk(objData.id,objData.isNPC);

        talkPannel.SetActive(isAction);
    }

    void Talk(int id,bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNPC)
        {
            talkText.text = talkData.Split(':')[0];
            int portraitIndex = int.Parse(talkData.Split(':')[1]);
            if(portraitIndex >= 1000)
            {
                portaitImage.sprite = talkManager.GetPortrait(portraitIndex);
                portaitImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                if(portraitIndex <= 100)
                {
                    talkManager.SelectTalk(portraitIndex);
                }
                portaitImage.color = new Color(1, 1, 1, 0);

            }

        }
        else
        {
            talkText.text = talkData;
            portaitImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    
    void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);
    }
}
