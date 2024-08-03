using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int grade = 1;
    public int hp = 100;//血量
    public int mp = 100;//蓝量
    public int coin = 200;//金币

    public int attack;
    public int attack_plus;
    public int defence;
    public int defence_plus;
    public int speed;
    public int speed_plus;
    public int point_remain;//剩余点数

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
