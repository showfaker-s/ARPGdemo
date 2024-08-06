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
        //�ж��Ƿ��Ǽ���״̬
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
        //�ѵ�ǰ���λ������Ϊ�������꣬��this.transform
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
        str += "����: " + info.name + "\n";
        str += "hp: " + info.hp + "\n";
        str += "mp: " + info.mp + "\n";
        str += "sell: " + info.price_sell + "\n";
        str += "buy: " + info.price_buy + "\n";
        return str;
    }
    string getEquipInfo(ObjInfo info)
    {
        string str = "";
        str += "����: " + info.name + "\n�������ͣ�";
        switch (info.dressType)
        {
            case DressType.Headgear:
                str += "ͷ��\n";
                break;
            case DressType.Armor:
                str += "����\n";
                break;
            case DressType.LeftHand:
                str += "����\n";
                break;
            case DressType.RightHand:
                str += "����\n";
                break;
            case DressType.Shoe:
                str += "Ь\n";
                break;
            case DressType.Accessory:
                str += "��Ʒ\n";
                break;
        }
        switch (info.charaType)
        {
            case CharaType.Swordman:
                str += "�������ͣ���ʿ\n";
                break;
            case CharaType.Magician:
                str += "�������ͣ�ħ��ʦ\n";
                break;
            case CharaType.Common:
                str += "�������ͣ�ͨ��\n";
                break;
        }
        str += "�˺�ֵ��: " + info.attack + "\n";
        str += "����ֵ��: " + info.def + "\n";
        str += "�˺�ֵ��: " + info.speed + "\n";
        str += "sell: " + info.price_sell + "\n";
        str += "buy: " + info.price_buy + "\n";
        return str;
    }
}
