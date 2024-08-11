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
    //装备属性
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
    //穿上某id的装备
    public bool Dress(int id)
    {
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        //1、不是装备类型
        if (info.type != ObjType.Equip) return false;
        if (player.heroType == HeroType.Swordman)
        {
            if (info.charaType == CharaType.Magician)
            {
                Debug.Log("穿戴失败，装备和角色职业不同");
                return false;
            }

        }
        if (player.heroType == HeroType.Magician)
        {
            if (info.charaType == CharaType.Swordman)
            {
                Debug.Log("穿戴失败，装备和角色职业不同");
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
            Inventory.Instance.GetID(item.id);//把卸下的装备放回物品栏
            //已经穿了同类型装备，只需要更新显示
            item.SetInfo(info);//更新显示
        }
        else
        {
            //没有穿装备
            GameObject itemGo = NGUITools.AddChild(parent, equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetInfo(info);
        }
        UpdateProperty();
        return true;
    }
    //卸下装备
    public void TakeOff(int id,GameObject equipItem)
    {
        
        //卸下装备放回bag
        Inventory.Instance.GetID(id);
        Destroy(equipItem);
        UpdateProperty();
    }
    //更新属性（逻辑层
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
    //加属性
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
