using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDrugNPC : NPC
{
    public GameObject PanelShop;
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)|| Input.GetMouseButtonDown(0))
        {
            ShopDrug.Instance.TransformState();
        }
    }
}
