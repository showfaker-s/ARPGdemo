using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : NPC
{
    public TweenPosition questTween;
    public UILabel desLabel;//任务描述

    public bool isInTask = false;//接受任务
    public bool isTaskOk = false;
    public int killCount = 0;//已经杀死多少只野怪

    public GameObject PanelQuest;
    public GameObject btnAccept;
    public GameObject btnCancel;
    public GameObject btnApply;
    private PlayerStatus status;
    //public GameObject btnClose;
    public AudioSource audio;
    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    //当鼠标位于这个collider之上时，会每一帧调用此方法
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//点击了老爷爷
        {
            audio.Play();
            ShowQuest();
            if (isInTask)
            {
                ShowTaskProgress();

            }
            else
            {
                ShowTaskDes();
            }
            
        }
    }
    public void ShowQuest()
    {
        //PanelQuest.SetActive(true);
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();//正向播放
    }
    private void HideQuest()
    {
        questTween.PlayReverse();//正向播放

    }
    public void OnClickClocsQuest()
    {
        HideQuest();
    }
    public void OnClickAccept()
    {
        ShowTaskProgress();
        isInTask = true;
    }

    private void ShowTaskDes()
    {
        desLabel.text = "任务：\n10只野怪\n奖励：\n1000金币";
        btnAccept.SetActive(true);
        btnCancel.SetActive(true);
        btnApply.SetActive(false);

    }
    private void ShowTaskProgress()
    {
        desLabel.text = "任务进度：\n" + killCount + "/10只野怪\n奖励：\n1000金币";
        btnAccept.SetActive(false);
        btnCancel.SetActive(false);
        btnApply.SetActive(true);
    }
    public void OnClickApply()
    {
        if (killCount >= 10)//完成任务
        {
            status.getCoin(1000);
            killCount = 0;
            ShowTaskDes();
            isInTask = false;
        }
        else
        {
            HideQuest();
        }
    }
    public void OnClickCancel()
    {
        HideQuest();
    }

}
