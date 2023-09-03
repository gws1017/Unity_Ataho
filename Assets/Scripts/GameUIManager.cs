using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    Text CurrentHPText;
    [SerializeField]
    Text MaxHPText;
    [SerializeField]
    Text CurrentMPText;
    [SerializeField]
    Text MaxMPText;
    [SerializeField]
    Text CurrentEXPText;
    [SerializeField]
    Text NeedEXPText;

    [SerializeField]
    RectTransform HPBar;
    [SerializeField]
    RectTransform MPBar;
    [SerializeField]
    RectTransform ExpBar;

    private void Update()
    {
        UpdateStatUI();
    }
    void UpdateStatUI()
    {
        CurrentHPText.text = PlayerStat.instance.currentHP.ToString();
        MaxHPText.text = PlayerStat.instance.hp.ToString();
        CurrentMPText.text = PlayerStat.instance.currentMP.ToString();
        MaxMPText.text = PlayerStat.instance.mp.ToString();
        CurrentEXPText.text = PlayerStat.instance.currentExp.ToString();
        NeedEXPText.text = PlayerStat.instance.needExp.ToString();


        HPBar.localScale = new Vector3(PlayerStat.instance.CurrentHPPercentage,1,1);
        MPBar.localScale = new Vector3(PlayerStat.instance.CurrentMPPercentage,1,1);
        ExpBar.localScale = new Vector3(PlayerStat.instance.CurrentExpPercentage, 1,1);
    }

}
