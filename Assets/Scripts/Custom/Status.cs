using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : BasePanel<Status>
{
    public UITweener tween;
    public UILabel atkLab;
    public UILabel defLab;
    public UILabel speedLab;
    public UILabel point_remainLab;
    public UILabel sumLab;
    public GameObject atkBtn;
    public GameObject defBtn;
    public GameObject speedBtn;

    private bool isShow = false;
    private PlayerStatus ps;

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    //根据PlayerStatus更新状态面板
    void UpdateShow()
    {
        atkLab.text = ps.attack + "+" + ps.attack_plus;
        defLab.text = ps.defence + "+" + ps.defence_plus;
        speedLab.text = ps.speed + "+" + ps.speed_plus;
        point_remainLab.text = ps.point_remain.ToString();
        sumLab.text = "伤害：" + (ps.attack + ps.attack_plus)
            + "  防御：" + (ps.defence + ps.defence_plus)
            + "  速度：" + (ps.speed + ps.speed_plus);
        if (ps.point_remain > 0)
        {
            atkBtn.SetActive(true);
            defBtn.SetActive(true);
            speedBtn.SetActive(true);
        }
        else
        {
            atkBtn.SetActive(false);
            defBtn.SetActive(false);
            speedBtn.SetActive(false);

        }
    }
    public void OnAtkPlusClick()
    {
        bool success = ps.AddPoint();
        if (success)
        {
            ps.attack_plus++;
            UpdateShow();
        }
    }
    public void OnDefPlusClick()
    {
        bool success = ps.AddPoint();
        if (success)
        {
            ps.defence_plus++;
            UpdateShow();
        }
    }
    public void OnSpeedPlusClick()
    {
        bool success = ps.AddPoint();
        if (success)
        {
            ps.speed_plus++;
            UpdateShow();
        }
    }
    private void Show()
    {
        UpdateShow();
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
