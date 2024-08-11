using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGrid : MonoBehaviour
{
    public UILabel numLabel;

    public int id = 0;
    public int num = 0;//����
    public ObjInfo info = null;

    public void AddNumber(int num = 1)
    {
        this.num += num;
        //������ʾ
        numLabel.text = this.num.ToString();
    }
    public bool MinusNumber(int num = 1)
    {
        if(this.num >= num)
        {
            this.num -= num;
            if (this.num ==0)
            {
                ClearInfo();//����洢����Ϣ
                //������Ʒ����
                Destroy(this.GetComponentInChildren<InventoryItem>().gameObject);
            }
            //������ʾ
            numLabel.text = this.num.ToString();
            return true;
        }
        return false;
    }
    //numĬ��Ϊ1,�������item�ŵ������������item
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
    //��ո��Ӵ����Ʒ��Ϣ
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
