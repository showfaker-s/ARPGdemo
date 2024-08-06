using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public static ObjectInfo _instance;

    private Dictionary<int, ObjInfo> objInfoDic = new Dictionary<int, ObjInfo>();

    public TextAsset objInfoListTxt;
    void Awake()
    {
        _instance = this;
        ReadInfo();
    }
    public ObjInfo GetInfoById(int id)
    {
        ObjInfo info = null;

        objInfoDic.TryGetValue(id, out info);

        return info;
    }

    //读取
    void ReadInfo()
    {
        string text = objInfoListTxt.text;
        //拆分
        //string[] strArray = text.Split("\n");
        string[] strArray = text.Split("\r\n");
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(",");
            ObjInfo info = new ObjInfo();//存储信息

            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            //初值
            ObjType type = ObjType.Drug;
            switch (str_type)
            {
                case "Drug":
                    type = ObjType.Drug;
                    break;
                case "Equip":
                    type = ObjType.Equip;
                    break;
                case "Mat":
                    type = ObjType.Mat;
                    break;
                default:
                    break;
            }
            //存储信息
            info.id = id; info.name = name; info.icon_name = icon_name; info.type = type;
            if (type == ObjType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                //存储信息
                info.hp = hp; info.mp = mp; info.price_sell = price_sell; info.price_buy = price_buy;
            }
            else if (type == ObjType.Equip)
            {
                info.attack = int.Parse(proArray[4]);
                info.def = int.Parse(proArray[5]);
                info.speed = int.Parse(proArray[6]);
                info.price_sell = int.Parse(proArray[9]);
                info.price_buy = int.Parse(proArray[10]);
                string str_dresstype = proArray[7];
                switch (str_dresstype)
                {
                    case "Headgear":
                        info.dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        info.dressType = DressType.Armor;
                        break;
                    case "LeftHand":
                        info.dressType = DressType.LeftHand;
                        break;
                    case "RightHand":
                        info.dressType = DressType.RightHand;
                        break;
                    case "Shoe":
                        info.dressType = DressType.Shoe;
                        break;
                    case "Accessory":
                        info.dressType = DressType.Accessory;
                        break;
                }
                string str_Charatype = proArray[8];
                switch (str_Charatype)
                {
                    case "Swordman":
                        info.charaType = CharaType.Swordman;
                        break;
                    case "Magician":
                        info.charaType = CharaType.Magician;
                        break;
                    case "Common":
                        info.charaType = CharaType.Common;
                        break;
                }
            }
            else if(type == ObjType.Mat)
            {
                Debug.Log("type == ObjType.Mat");
            }
            objInfoDic.Add(id, info);//添加到字典中，id为key，可以很方便的根据id查找到这个物品信息
        }
    }
}
public enum ObjType
{
    Drug,
    Equip,
    Mat
}
public enum DressType
{
    Headgear,
    Armor,
    LeftHand,
    RightHand,
    Shoe,
    Accessory
}
public enum CharaType
{
    Swordman,//剑士
    Magician,//魔法师
    Common//通用
}
public class ObjInfo
{
    public int id;
    public string name;
    public string icon_name;//存储在图集中的名称
    public ObjType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;

    public int attack;
    public int def;
    public int speed;
    public DressType dressType;
    public CharaType charaType;

}
