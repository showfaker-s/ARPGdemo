using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponNPC : NPC
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            WeaponUI.Instance.TransformState();
        }
    }
}
