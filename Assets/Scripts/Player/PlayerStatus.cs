using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HeroType
{
    Swordman,//剑士
    Magician,//魔法师
}
public class PlayerStatus : MonoBehaviour
{
    public string name = "默认名称";
    public HeroType heroType;
    public int grade = 1;
    public int hp = 100;//血量
    public int mp = 100;//蓝量
    public int hp_remain;
    public int mp_remain;
    public int coin = 200;//金币

    public int attack;
    public int attack_plus;
    public int defence;
    public int defence_plus;
    public int speed;
    public int speed_plus;
    public int point_remain;//剩余点数
    void Awake()
    {
        hp_remain = hp;
        mp_remain = mp;
    }
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
