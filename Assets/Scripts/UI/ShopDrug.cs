using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDrug : BasePanel<ShopDrug>
{
    private bool isShow = false;
    //private int buy_id = 0;
    public UITweener tween;
    public GameObject UIDialog;
    public UIInput numInput;
    public AudioSource audio;
    public void btnOK()
    {
        UIDialog.SetActive(false);
    }
    public void btnBuy1001()
    {
        Buy(1001);
    }
    public void btnBuy1002()
    {
        Buy(1002);
    }
    public void btnBuy1003()
    {
        Buy(1003);
    }
    private void Buy(int id)
    {
        //buy_id = id;//Ô­Ð´·¨
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        int num = int.Parse(numInput.value);
        int price_total = num * info.price_buy;
        if (Inventory.Instance.Buy(price_total))
        {
            if (num > 0)
            {
                Inventory.Instance.GetID(id, num);

            }
        }
        else {
            
            audio.Play();
        }

        ShowDialog();
    }
    public void ShowDialog()
    {
        UIDialog.SetActive(true);
        numInput.value = "0";
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
