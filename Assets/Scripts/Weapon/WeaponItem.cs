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

    //����id������idװ������ʾ
    public void SetId(int id)
    {
        info = ObjectInfo._instance.GetInfoById(id);
        //֮ǰû��дthis������this.idһֱ��0 
        this.id = id;
        icon.spriteName = info.icon_name;
        name_Label.text = info.name;
        if(info.attack > 0)
        {
            effect_Label.text = "�˺�+" + info.attack;
        }else if(info.def > 0)
        {
            effect_Label.text = "����" + info.def;
        }else if (info.speed > 0)
        {
            effect_Label.text = "�ٶ�" + info.speed;
        }
        else
        {
            effect_Label.text = "��ů";
        }
        buyPrice_Label.text = info.price_buy.ToString();

    }
    public void OnBuyClick()
    {
        //����WeaponUI�д�����ΪҪ����ui��ʾ
        //������������֪��id
        WeaponUI.Instance.OnBuyClick(id);
    }
}
