using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    public GameObject[] playerPref;
    private GameObject[] playerGO;
    
    private int selectIndex = 0;//��ǰѡ��Ľ�ɫ����
    private int playLen;//�ɹ�ѡ��Ľ�ɫ����

    public UIInput playerName;//����������

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
        //Խ�紦��
        selectIndex %= playLen;
        ShowCreate();
    }
    public void btnPre()
    {
        selectIndex--;
        //Խ�紦��
        if (selectIndex < 0)
        {
            selectIndex = playLen - 1;
        }
        ShowCreate();
    }
    //������ɫ
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
        //�Ѳ��ǵ�ǰѡ��Ľ�ɫ��������
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
        //�洢ѡ��Ľ�ɫ
        PlayerPrefs.SetInt("selectIndex", selectIndex);
        PlayerPrefs.SetString("playerName", playerName.value);
        //������һ������

    }
}
