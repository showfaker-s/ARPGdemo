using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int grade = 1;
    public int hp = 100;//Ѫ��
    public int mp = 100;//����
    public int coin = 200;//���

    public int attack;
    public int attack_plus;
    public int defence;
    public int defence_plus;
    public int speed;
    public int speed_plus;
    public int point_remain;//ʣ�����

    public void getCoin(int count)
    {
        coin += count;
    }
    public bool AddPoint()
    {
        if(point_remain >= 1)
        {
            point_remain -= 1;
            return true;
        }
        return false;
    }
}
