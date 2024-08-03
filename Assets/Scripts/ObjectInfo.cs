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

    //��ȡ
    void ReadInfo()
    {
        string text = objInfoListTxt.text;
        //���
        //string[] strArray = text.Split("\n");
        string[] strArray = text.Split("\r\n");
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(",");
            ObjInfo info = new ObjInfo();//�洢��Ϣ

            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            //��ֵ
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
            //�洢��Ϣ
            info.id = id; info.name = name; info.icon_name = icon_name; info.type = type;
            if (type == ObjType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                //�洢��Ϣ
                info.hp = hp; info.mp = mp; info.price_sell = price_sell; info.price_buy = price_buy;
            }
            if (objInfoDic.ContainsKey(id))
            {

            }
            else
            {
                objInfoDic.Add(id, info);//id��key������key��ѯv

            }
        }
    }
}
public enum ObjType
{
    Drug,
    Equip,
    Mat
}
public class ObjInfo
{
    public int id;
    public string name;
    public string icon_name;//�洢��ͼ���е�����
    public ObjType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;

}
