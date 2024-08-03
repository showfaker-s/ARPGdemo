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

    private int coinCount = 1000;//�������
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
    //ʰȡ��Ʒ
    public void collect()
    {

    }
    //ʰȡ��Ʒ����
    public void GetID(int id)
    {
        //1����������Ʒ�в����Ʒ�Ƿ����

        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList)
        {
            //��grid���б�ƥ���Ӧ��
            if(temp.id == id)
            {
                grid = temp;break;
            }
        }
        //2�������ڣ�num+1�����ڵ��������id���ж�
        if(grid != null)
        {
            grid.AddNumber();
        }
        //3�������ڵ����
        else
        {
            //grid.SetId(id);
            //�������ڣ��ҿշ��񣬰��´�����InventoryItem�ŵ�����
            foreach (InventoryItemGrid temp in itemGridList)
            {
                //�ҿո���
                if(temp.id == 0)
                {
                    grid = temp;break;
                }
            }
            //�������Ҹ���û��
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
