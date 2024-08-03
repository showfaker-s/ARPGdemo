using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGrid : MonoBehaviour
{
    public UILabel numLabel;

    public int id = 0;
    public int num = 0;//个数
    public ObjInfo info = null;

    public void AddNumber(int num = 1)
    {
        this.num += num;
        //更新显示
        numLabel.text = this.num.ToString();
    }
    //num默认为1,把类对象item放到格子里变成真的item
    public void SetId(int id, int num = 1)
    {
        this.id = id;
        info = ObjectInfo._instance.GetInfoById(id);
        InventoryItem item = this.GetComponentInChildren<InventoryItem>();
        item.SetIconName(id,info.icon_name);
        numLabel.enabled = true;
        this.num = num;
        numLabel.text = num.ToString();
    }
    //清空格子存的物品信息
    public void ClearInfo()
    {
        id = 0;
        info = null;
        num = 0;
        numLabel.text = "0";
        //numLabel.gameObject.SetActive(true);
        numLabel.enabled = false;
    }

}
