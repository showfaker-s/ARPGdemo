using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : BasePanel<EquipmentUI>
{
    private bool isShow = false;
    public UITweener tween;
    public GameObject Headgear;
    public GameObject Armor;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Shoe;
    public GameObject Accessory;
    void Start()
    {
        
    }


    void Update()
    {
        
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
