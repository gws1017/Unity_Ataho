using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("CurrentHP", PlayerStat.instance.currentHP);
        PlayerPrefs.SetInt("MaxHP", PlayerStat.instance.hp);
        PlayerPrefs.SetInt("CurrentMP", PlayerStat.instance.currentMP);
        PlayerPrefs.SetInt("MaxMP", PlayerStat.instance.mp);
        PlayerPrefs.SetInt("CurrentExp", PlayerStat.instance.currentExp);
        PlayerPrefs.SetInt("Atk", PlayerStat.instance.atk);
        PlayerPrefs.SetInt("Def", PlayerStat.instance.def);
        PlayerPrefs.SetInt("Spd", PlayerStat.instance.speed);
        PlayerPrefs.SetString("MapName", player.GetComponent<Player>().mapName);

        Debug.Log(player.GetComponent<Player>().mapName + "(save succ)" );
    }

    public void Recovery()
    {
        AudioManager.instance.PlaySFX("recovery");
        PlayerStat.instance.Recovery();
    }
}
