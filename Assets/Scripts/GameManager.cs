using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TalkManager talkManager;
    [SerializeField]
    Image portaitImage;
    [SerializeField]
    GameObject talkPannel;
    [SerializeField]
    GameObject scanObject;
    [SerializeField]
    Text talkText;
    [SerializeField]
    int talkIndex;

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
            if(portraitIndex > 0)
            {
                portaitImage.sprite = talkManager.GetPortrait(portraitIndex);
                portaitImage.color = new Color(1, 1, 1, 1);
            }
            else
                portaitImage.color = new Color(1, 1, 1, 0);

        }
        else
        {
            talkText.text = talkData;
            portaitImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
