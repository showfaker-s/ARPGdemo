using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemIcon : UIDragDropItem
{
    public int skillId;
    void Start()
    {
        base.Start();
    }
    protected override void OnDragDropStart()
    {
        skillId = transform.parent.GetComponent<SkillItem>().id;
        base.OnDragDropStart();
        transform.parent = transform.root;
        this.GetComponent<UISprite>().depth = 40;
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface!=null&&surface.tag == Tags.shortCut)
        {
            surface.GetComponent<ShortCutGrid>().SetSkill(skillId);
            //mTouch.current
        }
    }
}
