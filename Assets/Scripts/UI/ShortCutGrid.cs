using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShortCutType
{
    Skill,
    Drug,
    None

}
public class ShortCutGrid : MonoBehaviour
{
    public UISprite icon;
    private ShortCutType shortCutType = ShortCutType.None;
    private SkillInfo info;
    public KeyCode keyCode;

    public void SetSkill(int id)
    {
        info = SkillsInfo.Instance.GetInfoById(id);
        icon.spriteName = info.icon_name;
        icon.gameObject.SetActive(true);
        shortCutType = ShortCutType.Skill;
    }
    public void SetInventory(int id)
    {

    }
}
