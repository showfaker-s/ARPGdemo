using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : NPC
{
    public TweenPosition questTween;
    public UILabel desLabel;//��������

    public bool isInTask = false;//��������
    public bool isTaskOk = false;
    public int killCount = 0;//�Ѿ�ɱ������ֻҰ��

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

    //�����λ�����collider֮��ʱ����ÿһ֡���ô˷���
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//�������үү
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
        questTween.PlayForward();//���򲥷�
    }
    private void HideQuest()
    {
        questTween.PlayReverse();//���򲥷�

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
        desLabel.text = "����\n10ֻҰ��\n������\n1000���";
        btnAccept.SetActive(true);
        btnCancel.SetActive(true);
        btnApply.SetActive(false);

    }
    private void ShowTaskProgress()
    {
        desLabel.text = "������ȣ�\n" + killCount + "/10ֻҰ��\n������\n1000���";
        btnAccept.SetActive(false);
        btnCancel.SetActive(false);
        btnApply.SetActive(true);
    }
    public void OnClickApply()
    {
        if (killCount >= 10)//�������
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
