using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDes : MonoBehaviour
{
    public static InventoryDes _instance;
    public UILabel desLab;
    private float timer = 0;

    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        //判断是否是激活状态
        if(this.gameObject.activeInHierarchy == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void Show(int id)
    {
        //把当前鼠标位置设置为世界坐标，给this.transform
        this.transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.SetActive(true);  timer = 0.1f;
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        string des = "";
        switch (info.type)
        {
            case ObjType.Drug: des = getDrugInfo(info);
                break;
            case ObjType.Equip: des = getEquipInfo(info);
                break;
            case ObjType.Mat:
                break;
        }
        desLab.text = des;

    }
    string getDrugInfo(ObjInfo info)
    {
        string str = "";
        str += "名称: " + info.name + "\n";
        str += "hp: " + info.hp + "\n";
        str += "mp: " + info.mp + "\n";
        str += "sell: " + info.price_sell + "\n";
        str += "buy: " + info.price_buy + "\n";
        return str;
    }
    string getEquipInfo(ObjInfo info)
    {
        string str = "";
        str += "名称: " + info.name + "\n穿戴类型：";
        switch (info.dressType)
        {
            case DressType.Headgear:
                str += "头盔\n";
                break;
            case DressType.Armor:
                str += "盔甲\n";
                break;
            case DressType.LeftHand:
                str += "左手\n";
                break;
            case DressType.RightHand:
                str += "右手\n";
                break;
            case DressType.Shoe:
                str += "鞋\n";
                break;
            case DressType.Accessory:
                str += "饰品\n";
                break;
        }
        switch (info.charaType)
        {
            case CharaType.Swordman:
                str += "适用类型：剑士\n";
                break;
            case CharaType.Magician:
                str += "适用类型：魔法师\n";
                break;
            case CharaType.Common:
                str += "适用类型：通用\n";
                break;
        }
        str += "伤害值：: " + info.attack + "\n";
        str += "防御值：: " + info.def + "\n";
        str += "伤害值：: " + info.speed + "\n";
        str += "sell: " + info.price_sell + "\n";
        str += "buy: " + info.price_buy + "\n";
        return str;
    }
}
