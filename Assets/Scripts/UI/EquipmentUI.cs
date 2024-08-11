using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : BasePanel<EquipmentUI>
{
    private bool isShow = false;
    private PlayerStatus player;
    public UITweener tween;
    public GameObject Headgear;
    public GameObject Armor;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Shoe;
    public GameObject Accessory;
    public GameObject equipmentItem;
    //װ������
    public int attack = 0;
    public int def = 0;
    public int speed = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    private void Show()
    {
        tween.PlayForward();
        tween.enabled = true;
    }
    private void Hide()
    {
        tween.PlayReverse();
    }
    public void TransformState()
    {
        if (isShow == false)
        {
            Show();
            isShow = true;
        }
        else
        {
            Hide();
            isShow = false;
        }
    }
    //����ĳid��װ��
    public bool Dress(int id)
    {
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        //1������װ������
        if (info.type != ObjType.Equip) return false;
        if (player.heroType == HeroType.Swordman)
        {
            if (info.charaType == CharaType.Magician)
            {
                Debug.Log("����ʧ�ܣ�װ���ͽ�ɫְҵ��ͬ");
                return false;
            }

        }
        if (player.heroType == HeroType.Magician)
        {
            if (info.charaType == CharaType.Swordman)
            {
                Debug.Log("����ʧ�ܣ�װ���ͽ�ɫְҵ��ͬ");
                return false;
            }
        }

        GameObject parent = null;
        switch (info.dressType)
        {
            case DressType.Headgear:
                parent = Headgear;
                break;
            case DressType.Armor:
                parent = Armor;
                break;
            case DressType.LeftHand:
                parent = LeftHand;
                break;
            case DressType.RightHand:
                parent = RightHand;
                break;
            case DressType.Shoe:
                parent = Shoe;
                break;
            case DressType.Accessory:
                parent = Accessory;
                break;
        }
        EquipmentItem item = parent.GetComponentInChildren<EquipmentItem>();
        if (item != null)
        {
            Inventory.Instance.GetID(item.id);//��ж�µ�װ���Ż���Ʒ��
            //�Ѿ�����ͬ����װ����ֻ��Ҫ������ʾ
            item.SetInfo(info);//������ʾ
        }
        else
        {
            //û�д�װ��
            GameObject itemGo = NGUITools.AddChild(parent, equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetInfo(info);
        }
        UpdateProperty();
        return true;
    }
    //ж��װ��
    public void TakeOff(int id,GameObject equipItem)
    {
        
        //ж��װ���Ż�bag
        Inventory.Instance.GetID(id);
        Destroy(equipItem);
        UpdateProperty();
    }
    //�������ԣ��߼���
    public void UpdateProperty()
    {
        EquipmentItem headItem = Headgear.GetComponentInChildren<EquipmentItem>();
        EquipmentItem ArmorItem = Armor.GetComponentInChildren<EquipmentItem>();
        EquipmentItem LeftHandItem = LeftHand.GetComponentInChildren<EquipmentItem>();
        EquipmentItem RightHandItem = RightHand.GetComponentInChildren<EquipmentItem>();
        EquipmentItem ShoeItem = Shoe.GetComponentInChildren<EquipmentItem>();
        EquipmentItem AccessoryItem = Accessory.GetComponentInChildren<EquipmentItem>();
        PlusProperty(headItem);
        PlusProperty(ArmorItem);
        PlusProperty(LeftHandItem);
        PlusProperty(RightHandItem);
        PlusProperty(ShoeItem);
        PlusProperty(AccessoryItem);

    }
    //������
    public void PlusProperty(EquipmentItem item)
    {
        if(item != null)
        {
            ObjInfo info = ObjectInfo._instance.GetInfoById(item.id);
            this.attack += info.attack;
            this.def += info.def;
            this.speed += info.speed;
        }
    }
}
