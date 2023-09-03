using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    [SerializeField]
    int player_lv;

    public int needExp = 100;
    public int currentExp = 0;

    public int hp = 30;
    public int currentHP;
    public int mp = 30;
    public int currentMP;

    [SerializeField]
    int atk;
    [SerializeField]
    int def;
    [SerializeField]
    int speed;

    public float CurrentHPPercentage
    {
        get
        {
            return (float)currentHP / (float)hp;
        }
    }

    public float CurrentMPPercentage
    {
        get
        {
            return (float)currentMP / (float)mp;
        }
    }

    public float CurrentExpPercentage
    {
        get
        {
            return (float)currentExp / (float)needExp;
        }
    }

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
