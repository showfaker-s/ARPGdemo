using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUI : BasePanel<HeadUI>
{
    public UILabel HpLabel;
    public UILabel MpLabel;
    public UISlider Hp;
    public UISlider Mp;
    public UILabel name_icon;
    private PlayerStatus ps;
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
        UpdateUI();
    }
    public void UpdateUI()
    {
        HpLabel.text = ps.hp_remain + "/" + ps.hp;
        MpLabel.text = ps.mp_remain + "/" + ps.mp;
        Hp.value = ps.hp_remain;
        Mp.value = ps.mp_remain;
        name_icon.text = "Lv." + ps.grade + " " + ps.name;
    }
}
