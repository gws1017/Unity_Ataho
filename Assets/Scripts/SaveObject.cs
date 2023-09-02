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

        Debug.Log(PlayerPrefs.GetFloat("PlayerX") + "(save succ)" );
    }
}
