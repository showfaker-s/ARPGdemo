using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnContainer : MonoBehaviour
{
    
    //使用playerprefs保存场景数据、场景之间的数据
    //场景的分类：1.开始场景、2.角色选择界面、3.游戏玩家打怪界面

    //开始游戏
    public void OnNewGame()
    {
        //DataFromSave否
        PlayerPrefs.SetFloat("DataFromSave", 0);
        //加载场景2，角色选择

    }
    //加载已经保存的游戏
    public void OnLoadGame()
    {
        //加载场景3，可以从2中生成新数据，也可以加载已有的数据
        PlayerPrefs.SetFloat("DataFromSave", 1);//DataFromSave表示来自保存否

    }
}
