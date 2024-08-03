using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : BasePanel<Inventory>
{
    //public static Inventory _instance;
    //public TweenPosition tween;
    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinLabel;

    private int coinCount = 1000;//金币数量
    public bool isShow = false;

    public GameObject InventoryItem;
    public UITweener tween;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetID(UnityEngine.Random.Range(1001, 1004));
        }
    }
    //拾取物品
    public void collect()
    {

    }
    //拾取物品功能
    public void GetID(int id)
    {
        //1、在所有物品中查该物品是否存在

        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList)
        {
            //把grid和列表匹配对应上
            if(temp.id == id)
            {
                grid = temp;break;
            }
        }
        //2、若存在，num+1，存在的情况根据id来判断
        if(grid != null)
        {
            grid.AddNumber();
        }
        //3、不存在的情况
        else
        {
            //grid.SetId(id);
            //若不存在，找空方格，把新创建的InventoryItem放到里面
            foreach (InventoryItemGrid temp in itemGridList)
            {
                //找空格子
                if(temp.id == 0)
                {
                    grid = temp;break;
                }
            }
            //不存在且格子没满
            if(grid != null)
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, InventoryItem);
                itemGo.transform.localPosition = Vector3.zero;
                grid.SetId(id);
            }
        }
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
}
