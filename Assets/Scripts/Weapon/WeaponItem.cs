using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    private int id;
    private ObjInfo info;
    public UISprite icon;
    public UILabel name_Label;
    public UILabel effect_Label;
    public UILabel buyPrice_Label;

    //根据id，更新id装备的显示
    public void SetId(int id)
    {
        info = ObjectInfo._instance.GetInfoById(id);
        //之前没有写this，导致this.id一直是0 
        this.id = id;
        icon.spriteName = info.icon_name;
        name_Label.text = info.name;
        if(info.attack > 0)
        {
            effect_Label.text = "伤害+" + info.attack;
        }else if(info.def > 0)
        {
            effect_Label.text = "防御" + info.def;
        }else if (info.speed > 0)
        {
            effect_Label.text = "速度" + info.speed;
        }
        else
        {
            effect_Label.text = "保暖";
        }
        buyPrice_Label.text = info.price_buy.ToString();

    }
    public void OnBuyClick()
    {
        //传到WeaponUI中处理，因为要管理ui显示
        //而且这样才能知道id
        WeaponUI.Instance.OnBuyClick(id);
    }
}
