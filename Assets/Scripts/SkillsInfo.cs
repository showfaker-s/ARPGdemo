using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsInfo : BasePanel<SkillsInfo>
{
    public TextAsset skillsInfoTex;
    private Dictionary<int, SkillInfo> skillInfoDic = new Dictionary<int, SkillInfo>();

    void Awake()
    {
        ReadInfo();
    }
    //根据id，查到技能信息
    public SkillInfo GetInfoById(int id)
    {
        SkillInfo info = null;
        skillInfoDic.TryGetValue(id, out info);
        return info;
    }
    void ReadInfo()
    {
        string tex = skillsInfoTex.text;
        string[] strArray = tex.Split("\r\n");
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(",");
            SkillInfo info = new SkillInfo();//存储信息
            info.id = int.Parse(proArray[0]);
            info.name = proArray[1];
            info.icon_name = proArray[2];
            info.des = proArray[3];
            string applyType = proArray[4];
            switch (applyType)
            {
                case "Passive":info.applyType = ApplyType.Passive;break;
                case "Buff": info.applyType = ApplyType.Buff;break;
                case "SingleTarget": info.applyType = ApplyType.SingleTarget; break;
                case "MultiTarget": info.applyType = ApplyType.MultiTarget; break;
            }
            string applyProperty = proArray[5];
            switch (applyProperty)
            {
                case "Attack": info.applyProperty = ApplyProperty.Attack; break;
                case "Def": info.applyProperty = ApplyProperty.Def; break;
                case "":info.applyProperty = ApplyProperty.AttackSpeed; break;
                case "Hp": info.applyProperty = ApplyProperty.Hp; break;
                case "Mp": info.applyProperty = ApplyProperty.Mp; break;
                case "Speed": info.applyProperty = ApplyProperty.Speed; break;
            }
            info.applyValue = int.Parse(proArray[6]);
            info.applyTime = float.Parse(proArray[7]);
            info.mp = int.Parse(proArray[8]);
            info.cd = int.Parse(proArray[9]);
            string applicableRole = proArray[10];
            switch (applicableRole)
            {
                case "Magician": info.applicableRole = ApplicableRole.Magician; break;
                case "Swordman": info.applicableRole = ApplicableRole.Swordman; break;
            }
            int level = int.Parse(proArray[11]);
            info.level = level;
            string releaseType = proArray[12];
            switch (releaseType)
            {
                case "Enemy": info.releaseType = ReleaseType.Enemy; break;
                case "Position": info.releaseType = ReleaseType.Position; break;
                case "Self": info.releaseType = ReleaseType.Self; break;
            }
            float distance = float.Parse(proArray[13]);
            info.distance = distance;
            //存
            skillInfoDic.Add(info.id, info);
        }
    }
}
//适用角色
public enum ApplicableRole
{
    Swordman,
    Magician
}
//作用类型
public enum ApplyType
{
    Passive,
    Buff,
    SingleTarget,
    MultiTarget
}
//作用属性
public enum ApplyProperty
{
    Attack,
    Def,
    Speed,
    AttackSpeed,
    Hp,
    Mp,
}
//释放类型
public enum ReleaseType
{
    Self,//当前位置
    Enemy,//指定敌人位置
    Position//指定位置
}
public class SkillInfo
{
    public int id;
    public string name;
    public string icon_name;
    public string des;
    public ApplyType applyType;
    public ApplyProperty applyProperty;
    public int applyValue;
    public float applyTime;
    public int mp;
    public int cd;
    public ApplicableRole applicableRole;
    public int level;
    public ReleaseType releaseType;
    public float distance;

}