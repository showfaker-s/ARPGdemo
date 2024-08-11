using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : BasePanel<WeaponUI>
{
    private bool isShow = false;
    private int buy_id;
    private ObjInfo info;


    public UITweener tween;
    public int[] WeaponIdList;
    public UIGrid grid;
    public GameObject WeaponItem;
    public GameObject DialogPanel;
    public UIInput numberInput;

    void Start()
    {
        InitShopWeapon();
        DialogPanel.gameObject.SetActive(false);
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
    //初始化武器商店
    void InitShopWeapon()
    {
        foreach (int id in WeaponIdList)
        {
            GameObject item = NGUITools.AddChild(grid.gameObject, WeaponItem);
            grid.AddChild(item.transform);
            item.GetComponent<WeaponItem>().SetId(id);

        }
    }
    public void OnBuyClick(int id)
    {
        DialogPanel.gameObject.SetActive(true);
        numberInput.value = "0";
        buy_id = id;
        info = ObjectInfo._instance.GetInfoById(buy_id);
    }
    public void OnOkClick()
    {
        info = ObjectInfo._instance.GetInfoById(buy_id);
        int count = int.Parse(numberInput.value);
        if (count > 0)
        {
            int totalPrice = info.price_buy * count;
            if (Inventory.Instance.Buy(totalPrice))
            {
                //Inventory.Instance.GetID(buy_id);少了数量！
                Inventory.Instance.GetID(buy_id, count);
            }
        }
        //买成功或不成功都要做的事
        DialogPanel.gameObject.SetActive(false);

    }
}
