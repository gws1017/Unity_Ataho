using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            AudioManager.instance.PlayBGM(player.GetComponent<Player>().mapName);
            GameLoad();
        }
        else if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            AudioManager.instance.PlayBGM("title");
        }
    }
   
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
                    talkManager.SelectTalk(id,portraitIndex);
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
        StartCoroutine(LoadWait());
    }

    IEnumerator LoadWait()
    {
        yield return new WaitForSeconds(0.5f);
        if(PlayerStat.instance == null) StartCoroutine(LoadWait());
        else
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            PlayerStat.instance.currentHP = PlayerPrefs.GetInt("CurrentHP");
            PlayerStat.instance.hp = PlayerPrefs.GetInt("MaxHP");
            PlayerStat.instance.currentMP = PlayerPrefs.GetInt("CurrentMP");
            PlayerStat.instance.mp = PlayerPrefs.GetInt("MaxMP");
            PlayerStat.instance.currentExp = PlayerPrefs.GetInt("CurrentExp");

            PlayerStat.instance.atk = PlayerPrefs.GetInt("Atk");
            PlayerStat.instance.def = PlayerPrefs.GetInt("Def");
            PlayerStat.instance.speed = PlayerPrefs.GetInt("Spd");

            player.GetComponent<Player>().mapName = PlayerPrefs.GetString("MapName");

            player.transform.position = new Vector3(x, y, 0);

            Debug.Log("Load Data Success");

        }
    }
}
