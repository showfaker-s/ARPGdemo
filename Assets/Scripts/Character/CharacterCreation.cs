using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    public GameObject[] playerPref;
    private GameObject[] playerGO;
    
    private int selectIndex = 0;//当前选择的角色索引
    private int playLen;//可供选择的角色个数

    public UIInput playerName;//输入框的名字

    void Start()
    {
        playLen = playerPref.Length;
        playerGO = new GameObject[playLen];
        CreateCharact();
    }

    void Update()
    {

    }

    public void btnNext()
    {
        selectIndex++;
        //越界处理
        selectIndex %= playLen;
        ShowCreate();
    }
    public void btnPre()
    {
        selectIndex--;
        //越界处理
        if (selectIndex < 0)
        {
            selectIndex = playLen - 1;
        }
        ShowCreate();
    }
    //创建角色
    private void CreateCharact()
    {
        for (int i = 0; i < playLen; i++)
        {
            playerGO[i] = Instantiate(playerPref[i], this.transform.position, this.transform.rotation).gameObject;
        }
        ShowCreate();
    }
    private void ShowCreate()
    {
        playerGO[selectIndex].SetActive(true);
        //把不是当前选择的角色隐藏起来
        for (int i = 0; i < playLen; i++)
        {
            if(i != selectIndex)
            {
                playerGO[i].SetActive(false);
            }
        }
    }
    public void btnOK()
    {
        //存储选择的角色
        PlayerPrefs.SetInt("selectIndex", selectIndex);
        PlayerPrefs.SetString("playerName", playerName.value);
        //加载下一个场景

    }
}
