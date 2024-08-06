using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBar : MonoBehaviour
{
    public void OnStatusButtonClick()
    {
        Status.Instance.TransformState();
    }
    public void OnBagButtonClick()
    {
        Inventory.Instance.TransformState();
    }
    public void OnEquipButtonClick()
    {
        EquipmentUI.Instance.TransformState();

    }
    public void OnSkillButtonClick()
    {

    }
    public void OnSettingButtonClick()
    {

    }

}
