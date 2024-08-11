using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : BasePanel<SkillUI>
{
    private bool isShow = false;
    public UITweener tween;
    public UIGrid grid;
    //ublic SkillItem SkillItemPre;
    public GameObject SkillItemPre;
    public int[] Swordmanlist;
    public int[] Magicianlist;
    public PlayerStatus ps;
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
        int[] idlist = null;
        switch (ps.heroType)
        {
            case HeroType.Swordman:
                idlist = Swordmanlist;
                break;
            case HeroType.Magician:
                idlist = Magicianlist;
                break;
        }
        foreach (int id in idlist)
        {
            GameObject itemGo = NGUITools.AddChild(grid.gameObject, SkillItemPre);
            grid.AddChild(itemGo.transform);
            //itemGo.transform.localPosition = Vector3.zero;
            //¼Ó¸öcount
            itemGo.GetComponent<SkillItem>().SetId(id);
        }
    }


    private void Show()
    {
        tween.PlayForward();
        tween.enabled = true;
        UpdateShow();
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
    void UpdateShow()
    {
        SkillItem[] items = gameObject.GetComponentsInChildren<SkillItem>();
        foreach (SkillItem item in items)
        {
            item.UpdateShow(ps.grade);

        }
    }
}
