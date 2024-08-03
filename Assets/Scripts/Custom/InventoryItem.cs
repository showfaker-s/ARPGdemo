using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : UIDragDropItem
{
    public UISprite sprite;
    private bool isHover = false;
    private int id;

    void Start()
    {
        base.Start();
    }
    void Update()
    {
        base.Update();
        if(isHover)
        {
            InventoryDes._instance.Show(id);
        }
    }

    //��ק����ʱ���ñ�������surface����ק����ʱ����µ�����
    //surface������collider��һ�����߼�⣬��⵽�ĵ�һ������
    //ͨ����������ж���ק���������ﻹ�������ط�
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null)
        {
            //�ϵ�UI
            //�ϵ����ӣ�1���ո��ӡ�2���������
            if (surface.tag == Tags.Tag_invt_ItemGrid)
            {
                if (surface.transform.parent == this.transform.parent)//�������
                {

                }
                else//�ո���
                {
                    InventoryItemGrid oldGrid = this.transform.parent.GetComponent<InventoryItemGrid>();
                    InventoryItemGrid newGrid = surface.GetComponent<InventoryItemGrid>();
                    this.transform.parent = surface.transform;
                    ResetPos();
                    newGrid.SetId(oldGrid.id, oldGrid.num);
                    oldGrid.ClearInfo();
                }
            }//2.�ϵ�����Ʒ�ĸ��Ӵ�������
            else if (surface.tag == Tags.Tag_invt_Item)
            {
                InventoryItemGrid oldGrid = this.transform.parent.GetComponent<InventoryItemGrid>();
                InventoryItemGrid newGrid = surface.transform.parent.GetComponent<InventoryItemGrid>();
                int id = newGrid.id; int num = newGrid.num;
                newGrid.SetId(oldGrid.id, oldGrid.num);
                oldGrid.SetId(id, num);
            }
            this.ResetPos();
        }
    }
    public void ResetPos()
    {
        //��Ʒ�Ǹ��ӵ������壬��localPos��Ϊ0���ڸ����ھ���
        this.transform.localPosition = Vector3.zero;
    }
    public void SetId(int id)
    {
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        sprite.spriteName = info.icon_name;
    }
    public void SetIconName(int id,string icon_name)
    {
        this.id = id;
        sprite.spriteName = icon_name;
    }
    public void OnHoverOver() //ͣ����ʱ����Ӧ
    {
        isHover = true;
    }

    public void OnHoverOut() //���ߵ�ʱ����Ӧ
    {
        isHover = false;
    }
}
