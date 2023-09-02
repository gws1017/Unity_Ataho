using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    [SerializeField]
    int player_lv;
    [SerializeField]
    int[] needExp;
    [SerializeField]
    int currentExp = 0;

    [SerializeField]
    int hp = 30;
    [SerializeField]
    int currentHP;
    [SerializeField]
    int mp = 30;
    [SerializeField]
    int currentMP;

    [SerializeField]
    int atk;
    [SerializeField]
    int def;
    [SerializeField]
    int speed;


    void Start()
    {
        instance = this;
        currentHP = hp;
        currentMP = mp;
    }

    public void Hit(int enemyAtk)
    {
        int dmg;

        if (def >= enemyAtk)
            dmg = 0;
        else
            dmg = enemyAtk - def;

        
        currentHP -= dmg;
        if (currentHP <= 0)
            Debug.Log("Defeat");

        bool isMiss = (dmg >= 0 && dmg <= hp * 0.1);
        if (isMiss)
            AudioManager.instance.PlaySFX("miss");
        else
            AudioManager.instance.PlaySFX("hit");
    }

    public void Recovery()
    {
        currentHP = hp;
        currentMP = mp;
    }

}
