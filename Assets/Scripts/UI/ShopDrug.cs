using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDrug : BasePanel<ShopDrug>
{
    private bool isShow = false;
    public UITweener tween;


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
