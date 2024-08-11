using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    public UISprite sprite;
    private bool isHover = false;
    public int id;
    void Update()
    {
        if (isHover)
        {
            if (Input.GetMouseButtonDown(1)|| Input.GetMouseButtonDown(0))
            {

                EquipmentUI.Instance.TakeOff(id,this.gameObject);
            }
        } 
    }
    public void SetIconName(int id)
    {
        this.id = id;
        ObjInfo info = ObjectInfo._instance.GetInfoById(id);
        SetInfo(info);
    }
    public void SetInfo(ObjInfo info)
    {
        this.id = info.id;
        sprite.spriteName = info.icon_name;
    }
    //Êó±êÐü¸¡ÊÂ¼þ
    public void OnHover(bool isOver)
    {
        //Debug.Log("!!");
        isHover = isOver;
    }

}
