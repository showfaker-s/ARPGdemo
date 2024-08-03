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

    //拖拽结束时调用本方法，surface是拖拽结束时鼠标下的物体
    //surface是鼠标和collider做一个射线检测，检测到的第一个物体
    //通过这个物体判断拖拽到了网格里还是其它地方
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null)
        {
            //拖到UI
            //拖到格子：1、空格子。2、自身格子
            if (surface.tag == Tags.Tag_invt_ItemGrid)
            {
                if (surface.transform.parent == this.transform.parent)//自身格子
                {

                }
                else//空格子
                {
                    InventoryItemGrid oldGrid = this.transform.parent.GetComponent<InventoryItemGrid>();
                    InventoryItemGrid newGrid = surface.GetComponent<InventoryItemGrid>();
                    this.transform.parent = surface.transform;
                    ResetPos();
                    newGrid.SetId(oldGrid.id, oldGrid.num);
                    oldGrid.ClearInfo();
                }
            }//2.拖到有物品的格子处【交换
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
        //物品是格子的子物体，将localPos设为0会在格子内居中
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
    public void OnHoverOver() //停留的时候响应
    {
        isHover = true;
    }

    public void OnHoverOut() //移走的时候响应
    {
        isHover = false;
    }
}
