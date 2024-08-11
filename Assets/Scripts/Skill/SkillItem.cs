using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    public int id;
    public UISprite icon_name;
    public UILabel name;
    public UILabel applytype;
    public UILabel des;
    public UILabel Mp;
    public UISprite icon_Mask;
    private SkillInfo info;
    private bool isHover = false;

    //���¼�����ʾ
    public void SetId(int id)
    {
        this.id = id;
        info = SkillsInfo.Instance.GetInfoById(id);
        icon_name.spriteName = info.icon_name;
        name.text = info.name;
        switch (info.applyType)
        {
            case ApplyType.Passive:
                applytype.text = "��ǿ";
                break;
            case ApplyType.Buff:
                applytype.text = "buff";
                break;
            case ApplyType.SingleTarget:
                applytype.text = "����";
                break;
            case ApplyType.MultiTarget:
                applytype.text = "AOE";
                break;
        }
        des.text = info.des;
        Mp.text = info.mp + "MP";
    }
    public void UpdateShow(int level)
    {
        if (info.level <= level)
        {
            icon_Mask.gameObject.SetActive(false);
            //icon_name.enabled = true;
            icon_name.GetComponent<SkillItemIcon>().enabled = true;
        }
        else
        {
            icon_Mask.gameObject.SetActive(true);
            //���ܲ�����
            icon_name.GetComponent<SkillItemIcon>().enabled = false;

        }
    }
}
