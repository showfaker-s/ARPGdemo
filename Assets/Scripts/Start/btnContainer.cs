using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnContainer : MonoBehaviour
{
    
    //ʹ��playerprefs���泡�����ݡ�����֮�������
    //�����ķ��ࣺ1.��ʼ������2.��ɫѡ����桢3.��Ϸ��Ҵ�ֽ���

    //��ʼ��Ϸ
    public void OnNewGame()
    {
        //DataFromSave��
        PlayerPrefs.SetFloat("DataFromSave", 0);
        //���س���2����ɫѡ��

    }
    //�����Ѿ��������Ϸ
    public void OnLoadGame()
    {
        //���س���3�����Դ�2�����������ݣ�Ҳ���Լ������е�����
        PlayerPrefs.SetFloat("DataFromSave", 1);//DataFromSave��ʾ���Ա����

    }
}
